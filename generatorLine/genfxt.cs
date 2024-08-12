using addVehicle.Const;
using addVehicle.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addVehicle.generatorLine
{
    public class Genfxt
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool genAndSave(Info info)
        {
            log.Info($"Starting generation of {info.idName.ToLower()}.fxt");
            string templatefxd = template.templateFxd.Replace("{vehicleNameId}", info.idName.ToUpper()).Replace("{visualVehicleName}", info.visualName);
            #region save on modloader folder
            try
            {
                File.WriteAllText($"{info.modFolder}\\{info.idName.ToLower()}.fxt", templatefxd);
                log.Info("name.fxt file generated successfully.");
            }
            catch (Exception ex) 
            {
                log.Error($"Error on saving {info.idName.ToLower()}.fxt. Error:{ex.Message}");
                return false;
            }
            #endregion
            return true;
        }
    }
}
