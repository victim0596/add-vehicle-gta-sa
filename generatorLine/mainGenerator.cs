using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using addVehicle.generatorLine;

namespace addVehicle.generatorLinee
{
    public class MainGenerator
    {
        public async Task<List<Generator>> start(Info info) 
        {
            List<Generator> list = new List<Generator>();
            Generator checkGenHandling = await gen(info, "handling.cfg", false, true);
            list.Add(checkGenHandling);

            Generator checkgenCarcols = await gen(info, "carcols.dat", true, true);
            list.Add(checkgenCarcols);

            /*Generator checkgenCargrp = await gen(info, "cargrp.dat", true, true);
            list.Add(checkgenCargrp);*/

            Generator checkgenCarMods = await gen(info, "carmods.dat", true, true);
            list.Add(checkgenCarMods);

            Generator checkgenVehicles = await gen(info, "vehicles.ide", true, true);
            list.Add(checkgenVehicles);

            Generator audioSettings = await gen(info, "gtasa_vehicleAudioSettings.cfg", true, false);

            SaveFile save = new SaveFile();
            bool saveCheck = save.save(list, audioSettings, info);
            
            checkGenerator(list); //todo

            return list;
        }

        public Task<Generator> gen(Info info, string file, bool isLower, bool isOnData)
        {
            string path = isOnData ? $"{info.pathGta}\\data\\{file}" : $"{info.pathGta}\\{file}";
            Generator generator = new Generator { fileAnalized = file };
            var lines = File.ReadAllLines(path).ToArray();
            for (var i = 0; i < lines.Length; i += 1)
            {
                var line = lines[i];
                if (line.Contains(isLower ? info.nameVehicleToCopy.ToLower() : info.nameVehicleToCopy))
                {
                    generator.line = GenLineLoader.genLinee(line, info, file);
                    generator.result = true;
                    break;
                }
            }
            return Task.FromResult(generator);
        }

        public void checkGenerator(List<Generator> listGenerator)
        {
            string caption = "";
            string message = "";
            IList<string> notMandatory = new List<string> { "cargrp.dat", "carmods.dat" };
            if (!listGenerator.Where(x=> !notMandatory.Contains(x.fileAnalized)).Any(x => x.result == false))
            {
                caption = "Done";
                message = "New Vehicle added!";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(message, caption, button, icon, MessageBoxResult.OK);
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
