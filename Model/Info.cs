using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace addVehicle.Model
{
    public class Info
    {
        public string pathGta { get; set; }
        public string nameVehicleToCopy { get; set; }
        public int id { get; set; }
        public VehicleInfo txdVehicle { get; set; }
        public VehicleInfo dffVehicle { get; set; }
        public string visualName { get; set; }
        public string idName { get; set; }
        public string modLoaderFolder { get; set; }
        public string modFolder { get; set; }
        #region private
        private string errorMessage { get; set; }
        #endregion

        public Info() 
        { 
            txdVehicle = new VehicleInfo();
            dffVehicle = new VehicleInfo();
        }

        public bool checkField()
        {
            errorMessage = "";
            checkInput();
            checkPathGta();
            checkVehicleFile();
            if (errorMessage.Length > 0)
            {
                string caption = "Check Field";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show(errorMessage, caption, button, icon, MessageBoxResult.OK);
                return false;
            }
            return true;
        }
        #region checkField 
        private void checkVehicleFile()
        {
            if (string.IsNullOrEmpty(txdVehicle.path)) errorMessage += "There isn't any txd file loaded.\n";
            if (string.IsNullOrEmpty(dffVehicle.path)) errorMessage += "There isn't any dff file loaded.\n";
            if(!string.IsNullOrEmpty(txdVehicle.path) && !string.IsNullOrEmpty(dffVehicle.path))
            {
                if(txdVehicle.name != dffVehicle.name) errorMessage += "The name of txd and dff file are not the same.\n";
            }
        }

        private void checkInput()
        {
            if (id == 0) errorMessage+= "There isn't any valid number on id field.\n";
            if (string.IsNullOrEmpty(visualName)) errorMessage += "There isn't any visual name.\n";
            if (string.IsNullOrEmpty(idName)) errorMessage += "There isn't any id name.\n";
            if (!string.IsNullOrEmpty(idName) && idName.Length > 7 ) errorMessage += "The id name is too long (max 7 char).\n";
            if (string.IsNullOrEmpty(nameVehicleToCopy)) errorMessage += "There isn't vehicle to copy.\n";
        }

        private void checkPathGta()
        {
            if (string.IsNullOrEmpty(pathGta))
            {
                errorMessage += "The path is empty.\n";
                return;
            }
            DirectoryInfo d = new DirectoryInfo(pathGta);
            FileInfo[] gtaSaExe = d.GetFiles("gta_sa.exe");
            if (gtaSaExe.Length == 0)  errorMessage += "There isn't any gta_sa.exe in this folder.\n";
            //Check modloader folder exists
            modLoaderFolder = pathGta+"\\modloader";
            if (!Directory.Exists(modLoaderFolder)) errorMessage += "There isn't any modloader folder in this path.\n";
            //check vehicleAudioSettings
            DirectoryInfo d2 = new DirectoryInfo($"{pathGta}\\data");
            FileInfo[] vehicleAudioSettings = d2.GetFiles("gtasa_vehicleAudioSettings.cfg");
            if (vehicleAudioSettings.Length == 0) errorMessage += "There isn't any gtasa_vehicleAudioSettings.cfg in this folder.\n";
        }
        #endregion

    }
}
