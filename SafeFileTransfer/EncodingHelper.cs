using System;

namespace SafeFileTransferBackAndForth
{
    static class EncodingHelper
    {
        public static string Encode(byte[] dataToEncode) =>
            Convert.ToBase64String(dataToEncode);

        public static byte[] Decode(string dataToDecode) =>
            Convert.FromBase64String(dataToDecode);
    }
}
