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
using addVehicle.generatorLine.Contract;

namespace addVehicle.generatorLine.Concrete
{
    public class GenLineeOnLimitAdjuster : IGenLineeOnLimitAdjuster
    {
        private Dictionary<string, string> _linesEnding = new Dictionary<string, string>()
        {
            { "gtasa_vehicleAudioSettings.cfg", ";the end"},
            { "model_special_features.dat", "# A               B"}
        };
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public async Task<bool> genAndSave(Info info, Generator settings, string file)
        {
            log.Info($"Starting phase of vehicle setting on {file}");
            string path = $"{info.pathGta}\\data\\{file}";
            log.Info($"Reading {file} file...");
            try
            {
                var lines = await File.ReadAllLinesAsync(path);
                List<string> linesToList = lines.ToList();
                string endingLinee = _linesEnding.Where(x => x.Key == file).First().Value;
                var index = linesToList.FindIndex(x => x == endingLinee);
                if (index < 0)
                {
                    log.Error($"Error there isn't no {endingLinee} line in file {file}.");
                    return false;
                }
                linesToList.Insert(index, settings.line);
                string cfgModified = string.Join("\n", linesToList);
                log.Info($"Writing new setting line on {file}.");
                await File.WriteAllTextAsync(path, cfgModified);
                log.Info($"{file} updated with new setting linee");
                return true;
            }
            catch (Exception ex)
            {
                log.Error($"Error on reading or writing file {file}. Error: {ex.Message}");
                return false;
            }
        }

    }
}
