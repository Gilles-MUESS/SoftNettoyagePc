using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoftNettoyagePc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DirectoryInfo winTemp;
        public DirectoryInfo appTemp;
        public int totalRemovedFiles;

        public MainWindow()
        {
            InitializeComponent();
            winTemp = new DirectoryInfo(@"C:\Windows\Temp"); // Récupère les informations du dossier temporaire de Windows
            appTemp = new DirectoryInfo(System.IO.Path.GetTempPath()); // Récupère les informations du dossier temporaire du user
        }

        /**
         * Fonction de calcul du poids du dossier
         * */
        public long GetDirectorySize(DirectoryInfo dir)
        {
            return dir.GetFiles().Sum(file => file.Length) + dir.GetDirectories().Sum(subdir => GetDirectorySize(subdir));
        }

        /**
         * Fonction de nettoyage du dossier
         * */
        public void CleanDirectory(DirectoryInfo dir)
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                file.Delete();
                    totalRemovedFiles++;
                } catch(Exception ex) {
                    continue; 
                }
            }

            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                try
                {
                subdir.Delete(true);
                    totalRemovedFiles++;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        private void AnalyzeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CleanBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Le logiciel a été mis à jour", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void WebsiteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://www.softnettoyagepc.com") {
                    UseShellExecute = true
                });
            } catch(Exception ex)
            {
                MessageBox.Show("Impossible d'ouvrir le site web, erreur : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}