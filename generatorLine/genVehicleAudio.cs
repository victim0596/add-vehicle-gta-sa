using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;
using System.Windows.Shapes;

namespace addVehicle.generatorLine
{
    public class GenVehicleAudio
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool genAndSave(Info info, Generator audioSettings) 
        {
            log.Info("Starting phase of adding audio setting of vehicle on gtasa_vehicleAudioSettings.cfg");
            string path = $"{info.pathGta}\\data\\gtasa_vehicleAudioSettings.cfg";
            log.Info("Reading gtasa_vehicleAudioSettings.cfg file...");
            try
            {
                var lines = File.ReadAllLines(path).ToList();
                var index = lines.FindIndex(x => x == ";the end");
                lines.Insert(index, audioSettings.line);
                string cfgModified = string.Join("\n", lines);
                log.Info("Writing new audio line on gtasa_vehicleAudioSettings.cfg");
                File.WriteAllText(path, cfgModified);
                log.Info("gtasa_vehicleAudioSettings.cfg updated with new audio linee");
            }
            catch (Exception ex) 
            {
                log.Error($"Error on reading or writing file gtasa_vehicleAudioSettings.cfg. Error: {ex.Message}");
                return false;
            }
            return true; 
        }

    }
}
