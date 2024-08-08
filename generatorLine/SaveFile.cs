using addVehicle.Model;
using log4net;
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
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool save(IList<Generator> listGenerator, Generator audioSettings, Info info)
        {
            log.Info("Starting save phase.");
            //create dir for mod
            info.modFolder = $"{info.modLoaderFolder}\\{info.visualName}";
            if (!Directory.Exists(info.modFolder))
            {
                try
                {
                    Directory.CreateDirectory(info.modFolder);
                    log.Info("Mod directory created successfully");
                }
                catch (Exception ex) 
                {
                    log.Error(ex.Message);
                    return false;
                }
            }
            else
            {
                log.Error($"Already exist a directory with this name {info.modFolder}");
                return false;
            }
            //loader.txt
            MergeLine mergeLine = new MergeLine();
            bool checkMergeAndSave = mergeLine.mergeAndSave(listGenerator, info);
            //name.fxd
            Genfxt genfxt = new Genfxt();
            bool checkGenFxt = genfxt.genAndSave(info);
            //dff and txd
            GenModFile genModFile = new GenModFile();
            bool checkModFile = genModFile.genAndSave(info);
            //vehicleAudioSettings
            GenVehicleAudio genVehicleAudio = new GenVehicleAudio();
            bool checkVehicleAudio = genVehicleAudio.genAndSave(info, audioSettings);

            return checkMergeAndSave && checkGenFxt && checkModFile && checkVehicleAudio;
        }
    }
}
