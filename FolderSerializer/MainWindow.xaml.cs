using System.IO;
using System.Windows;
using System.Windows.Forms;
using FolderSerializer.DataOperations;

namespace FolderSerializer
{
    public partial class MainWindow : Window
    {
        private string pathToDat = "DataFile.dat";
        public MainWindow() =>
            InitializeComponent();

        private void Serialization_Click(object sender, RoutedEventArgs e)
        {
            var folderSerialization = new FolderSerialization();
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                folderSerialization.Serialize(dialog.SelectedPath,pathToDat);
            }
        }

        private void Deserialization_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var folderDeserialization = new FolderDeserialization();
                dialog.ShowDialog();
                
                folderDeserialization.Deserialize(dialog.SelectedPath, pathToDat);
            }
        }

        private void datChange_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                var folderDeserialization = new FolderDeserialization();
                dialog.ShowDialog();
                dialog.DefaultExt = "dat";
                dialog.AddExtension = false;
                pathToDat = Path.GetFullPath(dialog.FileName);
            }
        }
    }
}
