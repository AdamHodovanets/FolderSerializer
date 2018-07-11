using System;

namespace FolderSerializer
{
    [Serializable]
    class File
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
    }
    [Serializable]
    class Folder
    {
        public Folder[] SubFolders { get; set; }
        public File[] Files { get; set; }
        public string Name { get; set; }
    }
}
