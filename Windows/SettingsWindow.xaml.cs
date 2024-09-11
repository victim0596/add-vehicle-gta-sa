using addVehicle.Model;
using addVehicle.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace addVehicle.Windows
{
    /// <summary>
    /// Logica di interazione per SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public Setting settings = new Setting();
        public SettingsWindow()
        {
            InitializeComponent();
            loadSettings();
        }

        public void openFolder(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFolderDialog dialog = new();
            dialog.Multiselect = false;
            dialog.Title = "Select a folder";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                // Get the selected folder
                settings.pathGta = dialog.FolderName;
                string folderNameOnly = dialog.SafeFolderName;
                ButtonDirectory.Foreground = new SolidColorBrush(Colors.White);
                ButtonDirectory.Background = new SolidColorBrush(Colors.Green);
                ButtonDirectory.Content = dialog.FolderName;
            }
        }

        public void loadSettings()
        {
            //per info panel
            string infoShow = System.Configuration.ConfigurationManager.AppSettings["infoPanelShow"];
            bool infoBool = false;
            bool Checkinfo = bool.TryParse(infoShow, out infoBool);
            if (!Checkinfo) Errorbox.Show("infoPanelShow invalid value in app.config");
            else
            {
                settings.showInfoAlertAddPage = infoBool;
                checkBoxInfoPanel.IsChecked = infoBool;
            }
            //pathGta
            string pathGta = System.Configuration.ConfigurationManager.AppSettings["dirGta"];
            if (!string.IsNullOrEmpty(pathGta))
            {
                settings.pathGta = pathGta;
                ButtonDirectory.Foreground = new SolidColorBrush(Colors.White);
                ButtonDirectory.Background = new SolidColorBrush(Colors.Green);
                ButtonDirectory.Content = pathGta;
            }
        }

        public void saveSettings(object sender, RoutedEventArgs e)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["dirGta"].Value = settings.pathGta;
            config.AppSettings.Settings["infoPanelShow"].Value = settings.showInfoAlertAddPage.ToString();
            config.Save(ConfigurationSaveMode.Modified);
        }

        public void setInfoPanel(object sender, RoutedEventArgs e)
        {
            settings.showInfoAlertAddPage = checkBoxInfoPanel.IsChecked.Value;
        }
    }
}
