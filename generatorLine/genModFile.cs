using addVehicle.Const;
using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;

namespace addVehicle.generatorLine
{
    public class GenModFile
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool genAndSave(Info info)
        {
            log.Info("Starting copying and renaming of dff and txt file of vehicle.");
            #region save on modloader folder
            try
            {
                //dff
                File.Copy(info.dffVehicle.path, $"{info.modFolder}\\{info.idName.ToLower()}.dff");
                //txd
                File.Copy(info.txdVehicle.path, $"{info.modFolder}\\{info.idName.ToLower()}.txd");
                log.Info($"{info.idName.ToLower()}.dff and {info.idName.ToLower()}.txd generated successfully.");
            }
            catch (Exception ex) 
            {
                log.Error($"Error on copying and renaming the dff and txt. Error:{ex.Message}");
                return false;
            }

            #endregion
            return true;
        }
    }
}
