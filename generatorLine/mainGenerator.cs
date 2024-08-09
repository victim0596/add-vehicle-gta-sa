using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using addVehicle.generatorLine;
using log4net;

namespace addVehicle.generatorLinee
{
    public class MainGenerator
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<List<Generator>> start(Info info) 
        {
            log.Info("Started generation of configuration file for vehicle.");
            List<Generator> list = new List<Generator>();
            Generator checkGenHandling = await gen(info, "handling.cfg", false, true);
            list.Add(checkGenHandling);

            Generator checkgenCarcols = await gen(info, "carcols.dat", true, true);
            list.Add(checkgenCarcols);

            Generator checkgenCarMods = await gen(info, "carmods.dat", true, true);
            list.Add(checkgenCarMods);

            Generator checkgenVehicles = await gen(info, "vehicles.ide", true, true);
            list.Add(checkgenVehicles);

            Generator audioSettings = await gen(info, "gtasa_vehicleAudioSettings.cfg", true, true);

            SaveFile save = new SaveFile();
            bool saveCheck = save.save(list, audioSettings, info);
            log.Info("Finished generation of configuration file for vehicle.");
            checkGenerator(list, saveCheck);
            return list;
        }

        public Task<Generator> gen(Info info, string file, bool isLower, bool isOnData)
        {
            string path = isOnData ? $"{info.pathGta}\\data\\{file}" : $"{info.pathGta}\\{file}";
            Generator generator = new Generator { fileAnalized = file };
            log.Info($"Starting reading {file}.");
            try
            {
                var lines = File.ReadAllLines(path).ToArray();
                for (var i = 0; i < lines.Length; i += 1)
                {
                    var line = lines[i];
                    if (line.Contains(isLower ? info.nameVehicleToCopy.ToLower() : info.nameVehicleToCopy))
                    {
                        generator.line = GenLineLoader.genLinee(line, info, file);
                        generator.result = true;
                        log.Info($"Linee found for {info.nameVehicleToCopy} in {file}. \nDetail\n {generator.line}");
                        break;
                    }
                }
                if (string.IsNullOrEmpty(generator.line))
                {
                    generator.result = false;
                    log.Error($"No lines found for {info.nameVehicleToCopy} in file {file}.");
                }
            }
            catch (Exception e) 
            {
                generator.result = false;
                log.Error(e.Message);
            }
            log.Info($"Finish generated linee of {file}.");
            return Task.FromResult(generator);
        }

        public void checkGenerator(List<Generator> listGenerator, bool saveCheck)
        {
            string caption = "";
            string message = "";
            IList<string> notMandatory = new List<string> { "carmods.dat" };
            if (!listGenerator.Where(x=> !notMandatory.Contains(x.fileAnalized)).Any(x => x.result == false) && saveCheck)
            {
                caption = "Done";
                message = "New Vehicle added!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(message, caption, button, icon, MessageBoxResult.OK);
                log.Info("New vehicle added successfully.");
            }
            else
            {
                caption = "Error";
                message = "Something goes wrong, check the log for more information!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show(message, caption, button, icon, MessageBoxResult.OK);
            }
        }
    }
}
