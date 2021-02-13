using System;

namespace SafeFileTransferBackAndForth
{
    [Serializable]
    class FileEntry
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public byte[] FileContent { get; set; } = Array.Empty<byte>();
    }
}
