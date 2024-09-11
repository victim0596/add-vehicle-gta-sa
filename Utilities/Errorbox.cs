﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace addVehicle.Utilities
{
    public static class Errorbox
    {
        public static void Show(string errorMessage)
        {
            var caption = "Error";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(errorMessage, caption, button, icon, MessageBoxResult.OK);
        }
    }
}