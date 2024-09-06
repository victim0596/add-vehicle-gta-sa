using addVehicle.generatorLine.Contract;
using addVehicle.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace addVehicle
{
    /// <summary>
    /// Logica di interazione per AddVehicle.xaml
    /// </summary>
    public partial class AddWindow : Page
    {
        public Info info = new Info();
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMainGenerator _mainGenerator;
        public AddWindow(IMainGenerator mainGenerator)
        {
            InitializeComponent();
            loadComboItem();
            loadDefaultConfig();
            informationPanel();
            _mainGenerator = mainGenerator;
        }

        public AddWindow()
        {
        }

        public void loadComboItem()
        {
            comboVehicle.ItemsSource = Constant._vehicleList;
            comboTypeVehicle.ItemsSource = Constant._typeVehicleList;
        }
        public void loadDefaultConfig()
        {
            string dirGta = System.Configuration.ConfigurationManager.AppSettings["dirGta"];
            if (!string.IsNullOrEmpty(dirGta))
            {
                ButtonDirectory.Foreground = new SolidColorBrush(Colors.White);
                ButtonDirectory.Background = new SolidColorBrush(Colors.Green);
                ButtonDirectory.Content = dirGta;
                info.pathGta = dirGta;
            }
        }

        public void informationPanel()
        {
            string infoShow = System.Configuration.ConfigurationManager.AppSettings["infoPanelShow"];
            bool infoBool = false;
            bool Checkinfo = bool.TryParse(infoShow, out infoBool);
            if (!Checkinfo)
            {
                var caption = "Error";
                var message = "infoPanelShow invalid value in app.config";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show(message, caption, button, icon, MessageBoxResult.OK);
            }
            if (infoBool)
            {
                var caption = "Information";
                var message = "Remember first to edit fastman92limitAdjuster_GTASA.ini properly. Please, read the info.md.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(message, caption, button, icon, MessageBoxResult.OK);
            }
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
                info.pathGta = dialog.FolderName;
                string folderNameOnly = dialog.SafeFolderName;
                ButtonDirectory.Foreground = new SolidColorBrush(Colors.White);
                ButtonDirectory.Background = new SolidColorBrush(Colors.Green);
                ButtonDirectory.Content = dialog.FolderName;
            }
        }

        public void onDffVehicle(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".dff";
            dialog.Filter = "Dff file (.dff)|*.dff";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                info.dffVehicle.path = dialog.FileName;
                info.dffVehicle.name = dialog.SafeFileName.Split('.')[0];
                dffVehicle.Foreground = new SolidColorBrush(Colors.White);
                dffVehicle.Background = new SolidColorBrush(Colors.Green);
                dffVehicle.Content = dialog.SafeFileName;
            }
        }
        public void onTxdVehicle(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".txd";
            dialog.Filter = "Txd file (.txd)|*.txd";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                info.txdVehicle.path = dialog.FileName;
                info.txdVehicle.name = dialog.SafeFileName.Split('.')[0];
                txdVehicle.Foreground = new SolidColorBrush(Colors.White);
                txdVehicle.Background = new SolidColorBrush(Colors.Green);
                txdVehicle.Content = dialog.SafeFileName;
            }
        }


        public async void generateConfig(object sender, RoutedEventArgs e)
        {
            IList<string> specialVehicle = new List<string> { "ZR350", "HYDRA" };
            if (specialVehicle.Contains(info.nameVehicleToCopy))
            {
                var caption = "Information";
                var message = $"You are choosing a special vehicle. Add another line for {info.nameVehicleToCopy} in fastman92limitAdjuster_GTASA.ini with its ID number {info.id}.";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(message, caption, button, icon, MessageBoxResult.OK);
            }
            if (info.checkField())
            {
                List<Generator> genResult = await _mainGenerator.start(info);
            }
        }

        public void onSelectComboVehicle(object sender, RoutedEventArgs e)
        {
            info.nameVehicleToCopy = comboVehicle.SelectedItem.ToString();
        }
        public void onSelectComboTypeVehicle(object sender, RoutedEventArgs e)
        {
            info.nameTypeVehicleToCopy = comboTypeVehicle.SelectedItem.ToString();
        }

        public void setId(object sender, RoutedEventArgs e)
        {
            int valueId = 0;
            bool check = int.TryParse(textInputId.Text, out valueId);
            if (check) info.id = valueId;
        }

        public void setVisualName(object sender, RoutedEventArgs e)
        {
            string value = "";
            info.visualName = textInputVisualName.Text;
        }
        public void setVehicleNameId(object sender, RoutedEventArgs e)
        {
            string value = "";
            info.idName = textInputvehicleNameId.Text;
        }
    }
}
