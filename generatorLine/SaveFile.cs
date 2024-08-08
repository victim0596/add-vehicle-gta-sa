using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace addVehicle.generatorLine
{
    public class SaveFile
    {
        public bool save(IList<Generator> listGenerator, Generator audioSettings, Info info)
        {
            //create dir for mod
            info.modFolder = $"{info.modLoaderFolder}\\{info.visualName}";
            if (!Directory.Exists(info.modFolder))
            {
                Directory.CreateDirectory(info.modFolder);
            }
            //loader.txt
            MergeLine mergeLine = new MergeLine();
            bool checkMergeAndSave = mergeLine.mergeAndSave(listGenerator, info);
            //name.fxd
            Genfxd genfxd = new Genfxd();
            bool checkGenFxd = genfxd.genAndSave(info);
            //dff and txd
            GenModFile genModFile = new GenModFile();
            bool checkModFile = genModFile.genAndSave(info);
            //vehicleAudioSettings
            GenVehicleAudio genVehicleAudio = new GenVehicleAudio();
            bool checkVehicleAudio = genVehicleAudio.genAndSave(info, audioSettings);
            return true;
        }
    }
}
