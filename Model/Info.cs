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
            log.Info("Control field phase started.");
            checkInput();
            checkPathGta();
            checkVehicleFile();
            if (errorMessage.Length > 0)
            {
                string caption = "Check Field";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show(errorMessage, caption, button, icon, MessageBoxResult.OK);
                log.Info("Control field phase finished.");
                return false;
            }
            log.Info("Control field phase finished.");
            return true;
        }
        #region checkField 
        private void checkVehicleFile()
        {
            if (string.IsNullOrEmpty(txdVehicle.path))
            {
                errorMessage += "No txd file uploaded.\n";
                log.Error("No txd file uploaded.");
            }
            if (string.IsNullOrEmpty(dffVehicle.path))
            {
                errorMessage += "No dff file uploaded.\n";
                log.Error("No dff file uploaded.");
            }
            if(!string.IsNullOrEmpty(txdVehicle.path) && !string.IsNullOrEmpty(dffVehicle.path))
            {
                if (txdVehicle.name != dffVehicle.name)
                {
                    errorMessage += "Txd and dff files must have the same name.\n";
                    log.Error("Txd and dff files must have the same name.");
                }
            }
        }

        private void checkInput()
        {
            if (id == 0)
            {
                errorMessage += "No valid number in ID field.\n";
                log.Error("No valid number in ID field.");
            }
            if (string.IsNullOrEmpty(visualName))
            {
                errorMessage += "Empty visual name.\n";
                log.Error("Empty visual name.");
            }
            if (string.IsNullOrEmpty(idName))
            {
                errorMessage += "Empty ID name.\n";
                log.Error("Empty ID name.");
            }
            if (idName.Length > 7)
            {
                errorMessage += "ID name must have maximum 7 characters.\n";
                log.Error($"ID name must have maximum 7 characters {idName}.");
            }
            if (string.IsNullOrEmpty(nameVehicleToCopy))
            {
                errorMessage += "No vehicle found. Choose another reference.\n";
                log.Error("No vehicle found. Choose another reference.");
            }
            if(string.IsNullOrEmpty(nameTypeVehicleToCopy))
            {
                errorMessage += "No type vehicle found. Choose another option.\n";
                log.Error("No type vehicle found. Choose another option.");
            }
        }

        private void checkPathGta()
        {
            if (string.IsNullOrEmpty(pathGta))
            {
                errorMessage += "Empty GTA SA Directory.\n";
                log.Error("Empty GTA SA Directory.");
                return;
            }
            DirectoryInfo d = new DirectoryInfo(pathGta);
            FileInfo[] gtaSaExe = d.GetFiles("gta_sa.exe");
            if (gtaSaExe.Length == 0)
            {
                errorMessage += "No gta_sa.exe found in GTA SA Directory.\n";
                log.Error("No gta_sa.exe found in GTA SA Directory.");
            }
            //Check modloader folder exists
            modLoaderFolder = pathGta+"\\modloader";
            if (!Directory.Exists(modLoaderFolder))
            {
                errorMessage += "No modloader folder found in GTA SA Directory.\n";
                log.Error("No modloader folder found in GTA SA Directory.");
            }
            //check vehicleAudioSettings
            DirectoryInfo d2 = new DirectoryInfo($"{pathGta}\\data");
            FileInfo[] vehicleAudioSettings = d2.GetFiles("gtasa_vehicleAudioSettings.cfg");
            if (vehicleAudioSettings.Length == 0)
            {
                errorMessage += "No gtasa_vehicleAudioSettings.cfg found in GTA SA Directory data folder.\n";
                log.Error("No gtasa_vehicleAudioSettings.cfg found in GTA SA Directory data folder.");
            }//model_special_features.dat
            FileInfo[] modelSpecialFeatureSetting = d2.GetFiles("model_special_features.dat");
            if (modelSpecialFeatureSetting.Length == 0)
            {
                errorMessage += "No model_special_features.dat found in GTA SA Directory data folder.\n";
                log.Error("No model_special_features.dat found in GTA SA Directory data folder.");
            }
        }
        #endregion

    }
}
