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
using System.Windows.Shapes;

namespace addVehicle.generatorLinee
{
    public class MainGenerator
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IList<string> _listOfTwoLineeHandling = new List<string>{ Constant._typeAero, Constant._typeBike };

        public async Task<List<Generator>> start(Info info) 
        {
            log.Info("Started generation of configuration file for vehicle.");
            List<Generator> list = new List<Generator>();
            List<Generator> listLimitAdjuster = new List<Generator>();
            Generator checkGenHandling = await gen(info, "handling.cfg", false, true);
            list.Add(checkGenHandling);

            Generator checkgenCarcols = await gen(info, "carcols.dat", true, true);
            list.Add(checkgenCarcols);

            Generator checkgenCarMods = await gen(info, "carmods.dat", true, true);
            list.Add(checkgenCarMods);

            Generator checkgenVehicles = await gen(info, "vehicles.ide", true, true);
            list.Add(checkgenVehicles);

            Generator audioSettings = await gen(info, "gtasa_vehicleAudioSettings.cfg", true, true);
            listLimitAdjuster.Add(audioSettings);

            if(info.nameTypeVehicleToCopy == Constant._typeAero)
            {
                Generator specialFeature = genSpecialFeature(info, "model_special_features.dat");
                listLimitAdjuster.Add(specialFeature);
            }


            SaveFile save = new SaveFile();
            bool saveCheck = save.save(list, listLimitAdjuster, info);
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
                    var tempLinee = "";
                    if (line.Contains(isLower ? info.nameVehicleToCopy.ToLower() : info.nameVehicleToCopy))
                    {
                        if (_listOfTwoLineeHandling.Contains(info.nameTypeVehicleToCopy) && file == "handling.cfg")
                        {
                            tempLinee += line;
                            if(tempLinee.Split('\n').Length == 2)
                            {
                                generator.line = GenLineLoader.genLinee(line, info, file);
                                generator.result = true;
                                log.Info($"Linee found for {info.nameVehicleToCopy} in {file}. \nDetail\n {generator.line}");
                                break;
                            }
                        }
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


        public Generator genSpecialFeature(Info info, string file)
        {
            Generator generator = new Generator { fileAnalized = file };
            try
            {
                log.Info($"Starting generating line of {file}.");
                generator.line = $"{info.idName.ToLower()} {info.nameVehicleToCopy.ToLower()}";
                generator.result = true;
            }
            catch (Exception e)
            {
                generator.result = false;
                log.Error(e.Message);
            }
            log.Info($"Finish generated linee of {file}.");
            return generator;
        }


        public void checkGenerator(List<Generator> listGenerator, bool saveCheck)
        {
            string caption = "";
            string message = "";
            IList<string> notMandatory = new List<string> { "carmods.dat", "carcols.dat" };
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
