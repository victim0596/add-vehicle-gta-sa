using addVehicle.generatorLine.Contract;
using addVehicle.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace addVehicle.generatorLine.Concrete
{
    public class SaveFile : ISaveFile
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IGenfxt _genFxt;
        private readonly IGenLineeOnLimitAdjuster _genLineeOnLimitAdjuster;
        private readonly IMergeLine _mergeLine;
        private readonly IGenMod _genMod;

        public SaveFile(IGenfxt genFxt, IGenLineeOnLimitAdjuster genLineeOnLimitAdjuster, IMergeLine mergeLine, IGenMod genMod)
        {
            _genFxt = genFxt;
            _genLineeOnLimitAdjuster = genLineeOnLimitAdjuster;
            _mergeLine = mergeLine;
            _genMod = genMod;
        }

        public async Task<bool> save(IList<Generator> listGenerator, IList<Generator> listLimitAdjusterGenerator, Info info)
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
            try
            {
                //loader.txt
                bool checkMergeLine = await _mergeLine.mergeAndSave(listGenerator, info);
                //name.fxd
                bool checkGenFxt = await _genFxt.genAndSave(info);
                //dff and txd
                bool checkGenMod = await _genMod.genAndSave(info);
                //vehicleAudioSettings
                bool checkAudio = await _genLineeOnLimitAdjuster.genAndSave(info, listLimitAdjusterGenerator.Where(x => x.fileAnalized == "gtasa_vehicleAudioSettings.cfg").First(), "gtasa_vehicleAudioSettings.cfg");
                if (info.nameTypeVehicleToCopy == Constant._typeAero)
                {
                    //modelspecialfeature
                    bool checkSpecial = await _genLineeOnLimitAdjuster.genAndSave(info, listLimitAdjusterGenerator.Where(x => x.fileAnalized == "model_special_features.dat").First(), "model_special_features.dat");
                    return checkMergeLine && checkGenFxt && checkGenMod && checkAudio && checkSpecial;   
                }
                return checkMergeLine && checkGenFxt && checkGenMod && checkAudio;
            }
            catch (Exception ex)
            {
                return false;
            }           
        }
    }
}
