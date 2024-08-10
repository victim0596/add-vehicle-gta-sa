using log4net;
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
        public string nameTypeVehicleToCopy { get; set; }
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
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Info() 
        { 
            txdVehicle = new VehicleInfo();
            dffVehicle = new VehicleInfo();
        }

        public bool checkField()
        {
            errorMessage = "";
            log.Info("Start field control phase");
            checkInput();
            checkPathGta();
            checkVehicleFile();
            if (errorMessage.Length > 0)
            {
                string caption = "Check Field";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show(errorMessage, caption, button, icon, MessageBoxResult.OK);
                log.Info("End of field control phase");
                return false;
            }
            log.Info("End of field control phase"); 
            return true;
        }
        #region checkField 
        private void checkVehicleFile()
        {
            if (string.IsNullOrEmpty(txdVehicle.path))
            {
                errorMessage += "There isn't any txd file loaded.\n";
                log.Error("There isn't any txd file loaded.");
            }
            if (string.IsNullOrEmpty(dffVehicle.path))
            {
                errorMessage += "There isn't any dff file loaded.\n";
                log.Error("There isn't any dff file loaded.");
            }
            if(!string.IsNullOrEmpty(txdVehicle.path) && !string.IsNullOrEmpty(dffVehicle.path))
            {
                if (txdVehicle.name != dffVehicle.name)
                {
                    errorMessage += "The name of txd and dff file are not the same.\n";
                    log.Error("The name of txd and dff file are not the same.");
                }
            }
        }

        private void checkInput()
        {
            if (id == 0)
            {
                errorMessage += "There isn't any valid number on id field.\n";
                log.Error("There isn't any valid number on id field.");
            }
            if (string.IsNullOrEmpty(visualName))
            {
                errorMessage += "There isn't any visual name.\n";
                log.Error("There isn't any visual name.");
            }
            if (string.IsNullOrEmpty(idName))
            {
                errorMessage += "There isn't any id name.\n";
                log.Error("There isn't any id name.");
            }
            if (!string.IsNullOrEmpty(idName) && idName.Length > 7)
            {
                errorMessage += "The id name is too long (max 7 char).\n";
                log.Error("The id name is too long (max 7 char).");
            }
            if (string.IsNullOrEmpty(nameVehicleToCopy))
            {
                errorMessage += "There isn't vehicle to copy.\n";
                log.Error("There isn't vehicle to copy.");
            }
            if(string.IsNullOrEmpty(nameTypeVehicleToCopy))
            {
                errorMessage += "There isn't any type of vehicle.\n";
                log.Error("There isn't any type of vehicle.");
            }
        }

        private void checkPathGta()
        {
            if (string.IsNullOrEmpty(pathGta))
            {
                errorMessage += "The gta path is empty.\n";
                log.Error("The gta path is empty.");
                return;
            }
            DirectoryInfo d = new DirectoryInfo(pathGta);
            FileInfo[] gtaSaExe = d.GetFiles("gta_sa.exe");
            if (gtaSaExe.Length == 0)
            {
                errorMessage += "There isn't any gta_sa.exe in this gta path.\n";
                log.Error("There isn't any gta_sa.exe in this gta path.");
            }
            //Check modloader folder exists
            modLoaderFolder = pathGta+"\\modloader";
            if (!Directory.Exists(modLoaderFolder))
            {
                errorMessage += "There isn't any modloader folder in this gta path.\n";
                log.Error("There isn't any modloader folder in this gta path.");
            }
            //check vehicleAudioSettings
            DirectoryInfo d2 = new DirectoryInfo($"{pathGta}\\data");
            FileInfo[] vehicleAudioSettings = d2.GetFiles("gtasa_vehicleAudioSettings.cfg");
            if (vehicleAudioSettings.Length == 0)
            {
                errorMessage += "There isn't any gtasa_vehicleAudioSettings.cfg in data folder.\n";
                log.Error("There isn't any gtasa_vehicleAudioSettings.cfg in data folder.");
            }//model_special_features.dat
            FileInfo[] modelSpecialFeatureSetting = d2.GetFiles("model_special_features.dat");
            if (modelSpecialFeatureSetting.Length == 0)
            {
                errorMessage += "There isn't any model_special_features.dat in data folder.\n";
                log.Error("There isn't any model_special_features.dat in data folder.");
            }
        }
        #endregion

    }
}
