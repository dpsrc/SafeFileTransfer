using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SafeFileTransferBackAndForth
{
    static class CryptoHelper
    {
        static readonly SymmetricAlgorithm cryptoServiceProvider = new AesCryptoServiceProvider();
        public static readonly int lengthOfInitializationVector = cryptoServiceProvider.BlockSize >> 3;
        public static readonly int lengthOfKey = cryptoServiceProvider.KeySize >> 3;

        internal static Func<SymmetricAlgorithm> CreateCryptoServiceProvider { get; set; } = () => cryptoServiceProvider;

        public static byte[] Encrypt(byte[] dataToEncrypt, string initializationVector, string cryptoKey)
        {
            byte[] key = Encoding.UTF8.GetBytes(cryptoKey);
            byte[] iv = Encoding.UTF8.GetBytes(initializationVector);

            using MemoryStream streamMemory = new MemoryStream();
            using CryptoStream streamCrypto = new CryptoStream(streamMemory, CreateCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write);
            streamCrypto.Write(dataToEncrypt, 0, dataToEncrypt.Length);
            streamCrypto.FlushFinalBlock();
            
            return streamMemory.ToArray();
        }

        public static byte[] Decrypt(byte[] dataToDecrypt, string initializationVector, string cryptoKey)
        {
            byte[] key = Encoding.UTF8.GetBytes(cryptoKey);
            byte[] iv = Encoding.UTF8.GetBytes(initializationVector);

            using MemoryStream streamMemory = new MemoryStream();
            using CryptoStream streamCrypto = new CryptoStream(streamMemory, CreateCryptoServiceProvider().CreateDecryptor(key, iv), CryptoStreamMode.Write);
            streamCrypto.Write(dataToDecrypt, 0, dataToDecrypt.Length);
            streamCrypto.FlushFinalBlock();
            
            return streamMemory.ToArray();
        }
    }
}
