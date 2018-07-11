using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FolderSerializer.DataOperations
{
    class FolderDeserialization
    {
        public void Deserialize(string path, string pathToDat)
        {
            Folder data;
            var fs = new FileStream(pathToDat, FileMode.Open);
            
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                data = (Folder)formatter.Deserialize(fs);
                this.GenerateFolder(data, $"{path}/{data.Name}");
                System.Diagnostics.Process.Start($"{path}/{data.Name}");
            }
            catch (SerializationException ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed to deserialize. Reason: " + ex.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public void GenerateFolder(Folder folder,string path = default(string))
        {
            Directory.CreateDirectory($"{path}/");
            foreach(var file in folder.Files)
                System.IO.File.WriteAllBytes($"{path}/{file.Name}", file.Data);
            foreach(var item in folder.SubFolders)
                GenerateFolder(item,$"{path}/{item.Name}");
        }
    }
}
