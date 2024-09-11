using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace addVehicle.Utilities
{
    public static class Infobox
    {
        public static void Show(string infoMessage)
        {
            var caption = "Information";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(infoMessage, caption, button, icon, MessageBoxResult.OK);
        }
    }
}
