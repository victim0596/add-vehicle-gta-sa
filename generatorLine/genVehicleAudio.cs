using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace addVehicle.generatorLine
{
    public class GenVehicleAudio
    {
        public bool genAndSave(Info info, Generator audioSettings) 
        {
            string path = $"{info.pathGta}\\data\\gtasa_vehicleAudioSettings.cfg";
            var lines = File.ReadAllLines(path).ToList();
            var index = lines.FindIndex(x => x == ";the end");
            lines.Insert(index, audioSettings.line);
            string cfgModified = string.Join("\n", lines);
            File.WriteAllText(path, cfgModified);
            return true; 
        }

    }
}
