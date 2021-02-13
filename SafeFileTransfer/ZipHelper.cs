using ICSharpCode.SharpZipLib.Zip;

using System;
using System.IO;

namespace SafeFileTransferBackAndForth
{
    static class ZipHelper
    {
        private static readonly string zipEntryFileName = Guid.NewGuid().ToString();

        public static byte[] ZipUp(Stream streamToZip, string password = null)
        {
            byte[] resultData = Array.Empty<byte>();

            using (MemoryStream streamResult = new MemoryStream())
            using (ZipOutputStream zipOutputStream = new ZipOutputStream(streamResult))
            {
                zipOutputStream.SetLevel(9); // Maximum compression level

                if (!string.IsNullOrEmpty(password))
                {
                    zipOutputStream.Password = password;
                }

                ZipEntry zipEntry = new ZipEntry(zipEntryFileName);
                zipOutputStream.PutNextEntry(zipEntry);

                streamToZip.Position = 0;
                streamToZip.CopyTo(zipOutputStream);

                zipOutputStream.Finish();

                resultData = streamResult.ToArray();
            }

            return resultData;
        }

        public static byte[] UnZip(Stream streamToUnZip, string password = null)
        {
            byte[] resultData = Array.Empty<byte>();

            using (MemoryStream streamResult = new MemoryStream())
            using (ZipFile zipFile = new ZipFile(streamToUnZip, true))
            {
                if (!string.IsNullOrEmpty(password))
                {
                    zipFile.Password = password;
                }

                ZipEntry zipEntry = zipFile.GetEntry(zipEntryFileName);

                zipFile.GetInputStream(0).CopyTo(streamResult);

                resultData = streamResult.ToArray();
            }

            return resultData;
        }
    }
}
