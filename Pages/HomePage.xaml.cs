using addVehicle.generatorLine.Contract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace addVehicle.Pages
{
    /// <summary>
    /// Logica di interazione per Homepage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private readonly IMainGenerator _mainGenerator;
        public HomePage(IMainGenerator mainGenerator)
        {
            InitializeComponent();
            _mainGenerator = mainGenerator;
        }
        public HomePage()
        {
        }
        private void goToAddPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddPage(_mainGenerator));
        }
        public void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
