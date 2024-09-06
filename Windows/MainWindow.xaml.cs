using addVehicle.generatorLine;
using addVehicle.generatorLine.Concrete;
using addVehicle.generatorLine.Contract;
using addVehicle.Model;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MainWindow()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Start application.");
            InitializeComponent();
        }

       
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            log.Info("Application closed.");
        }
    }
}
