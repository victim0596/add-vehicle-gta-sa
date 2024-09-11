using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace addVehicle.Utilities
{
    public static class Warningbox
    {
        public static void Show(string warningMessage, string title = "Warning")
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show(warningMessage, title, button, icon, MessageBoxResult.OK);
        }
    }
}
