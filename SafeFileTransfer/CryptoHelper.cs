using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SafeFileTransferBackAndForth
{
    static class CryptoHelper
    {
        public const int lengthOfInitializationVector = 8;
        public const int lengthOfTripleDesKey = 16;

        static readonly SymmetricAlgorithm cryptoServiceProvider = new TripleDESCryptoServiceProvider();

        public static byte[] Encrypt(byte[] dataToEncrypt, string initializationVector, string tripleDesKey)
        {
            byte[] key = Encoding.UTF8.GetBytes(tripleDesKey);
            byte[] iv = Encoding.UTF8.GetBytes(initializationVector);

            byte[] resultByteArray = null;

            using (MemoryStream streamMemory = new MemoryStream())
            using (CryptoStream streamCrypto = new CryptoStream(streamMemory, cryptoServiceProvider.CreateEncryptor(key, iv), CryptoStreamMode.Write))
            {
                streamCrypto.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                streamCrypto.FlushFinalBlock();
                resultByteArray = streamMemory.ToArray();
            }

            return resultByteArray;
        }

        public static byte[] Decrypt(byte[] dataToDecrypt, string initializationVector, string tripleDesKey)
        {
            byte[] key = Encoding.UTF8.GetBytes(tripleDesKey);
            byte[] iv = Encoding.UTF8.GetBytes(initializationVector);

            byte[] resultByteArray = null;

            using (MemoryStream streamMemory = new MemoryStream())
            using (CryptoStream streamCrypto = new CryptoStream(streamMemory, cryptoServiceProvider.CreateDecryptor(key, iv), CryptoStreamMode.Write))
            {
                streamCrypto.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                streamCrypto.FlushFinalBlock();
                resultByteArray = streamMemory.ToArray();
            }

            return resultByteArray;
        }
    }
}
