using System.Windows;
using System.Windows.Forms;
using FolderSerializer.DataOperations;

namespace FolderSerializer
{
    public partial class MainWindow : Window
    {
        public MainWindow() =>
            InitializeComponent();

        private void Serialization_Click(object sender, RoutedEventArgs e)
        {
            var folderSerialization = new FolderSerialization();
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                folderSerialization.Serialize(dialog.SelectedPath);
            }
        }

        private void Deserialization_Click(object sender, RoutedEventArgs e)
        {
            var folderDeserialization = new FolderDeserialization();
            folderDeserialization.Deserialize();
        }
    }
}
