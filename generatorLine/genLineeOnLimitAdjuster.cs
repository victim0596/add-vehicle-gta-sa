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
    public class GenLineeOnLimitAdjuster
    {
        private Dictionary<string, string> _linesEnding = new Dictionary<string, string>()
        {
            { "gtasa_vehicleAudioSettings.cfg", ";the end"},
            { "model_special_features.dat", "# A               B"}
        };
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool genAndSave(Info info, Generator settings, string file) 
        {
            log.Info($"Starting phase of vehicle setting on {file}");
            string path = $"{info.pathGta}\\data\\{file}";
            log.Info($"Reading {file} file...");
            try
            {
                var lines = File.ReadAllLines(path).ToList();
                string endingLinee = _linesEnding.Where(x => x.Key == file).First().Value;
                var index = lines.FindIndex(x => x == endingLinee);
                if(index < 0)
                {
                    log.Error($"Error there isn't no {endingLinee} line in file {file}.");
                    return false;
                }
                lines.Insert(index, settings.line);
                string cfgModified = string.Join("\n", lines);
                log.Info($"Writing new setting line on {file}.");
                File.WriteAllText(path, cfgModified);
                log.Info($"{file} updated with new setting linee");
            }
            catch (Exception ex) 
            {
                log.Error($"Error on reading or writing file {file}. Error: {ex.Message}");
                return false;
            }
            return true; 
        }

    }
}
