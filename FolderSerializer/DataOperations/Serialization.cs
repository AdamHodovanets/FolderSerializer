using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FolderSerializer.DataOperations
{

    class FolderSerialization
    {
        public void Serialize(string path, string pathToDat)
        {
            var fs = new FileStream(pathToDat, FileMode.Create);
            

            var formatter = new BinaryFormatter();
            try
            {

                formatter.Serialize(fs, new Folder
                {
                    Files = this.GetFiles(path).ToArray(),
                    Name = Path.GetFileName(path),
                    SubFolders = this.GetDirectories(path).ToArray()
                });
            }
            catch (SerializationException ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed to serialize. Reason: " + ex.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public IEnumerable<Folder> GetDirectories(string root)
        {
            foreach (var dir in System.IO.Directory.GetDirectories(root))
            {
                var dirInfo = new DirectoryInfo(dir);
                var directory = new Folder
                {
                    Name = dirInfo.Name,
                    Files = GetFiles(dir).ToArray(),
                    SubFolders = GetDirectories(dir).ToArray()
                };
                yield return directory;
            }
        }

        public IEnumerable<File> GetFiles(string dir)
        {
            foreach (var file in System.IO.Directory.GetFiles(dir))
            {
                var fInfo = new FileInfo(file);

                yield return new File
                {
                    Data = System.IO.File.ReadAllBytes(file),
                    Name = fInfo.Name
                };
            }
        }
    }
}
