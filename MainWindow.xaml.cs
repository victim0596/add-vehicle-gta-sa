using addVehicle.generatorLine;
using addVehicle.generatorLinee;
using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Info info = new Info();
        public MainWindow()
        {
            InitializeComponent();
            loadComboItem();
        }

        public void loadComboItem()
        {
            comboVehicle.ItemsSource = Constant._vehicleList;
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
            if (info.checkField())
            {
                MainGenerator gen = new MainGenerator();
                List<Generator> genResult = await gen.start(info);
            }
            /*Info infoGen = new Info();
            infoGen.nameVehicleToCopy = "LANDSTAL";
            infoGen.id = 580;
            infoGen.idName = "test";
            string check = GenLineLoader.genLinee("400,\tlandstal, \tlandstal, \tcar, \t\tLANDSTAL, \tLANDSTK, \tnull,\tnormal, \t10,\t0,\t0,\t\t-1, 0.768, 0.768,\t0\r\n", infoGen, "vehicles.ide");*/
        }

        public void onSelectComboVehicle(object sender, RoutedEventArgs e)
        {
            info.nameVehicleToCopy = comboVehicle.SelectedItem.ToString();
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
