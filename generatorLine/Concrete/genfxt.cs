using addVehicle.Const;
using addVehicle.generatorLine.Contract;
using addVehicle.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace addVehicle.generatorLine.Concrete
{
    public class Genfxt: IGenfxt
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public async Task<bool> genAndSave(Info info)
        {
            log.Info($"Starting generation of {info.idName.ToLower()}.fxt");
            string templatefxd = template.templateFxd.Replace("{vehicleNameId}", info.idName.ToUpper()).Replace("{visualVehicleName}", info.visualName);
            #region save on modloader folder
            try
            {
                await File.WriteAllTextAsync($"{info.modFolder}\\{info.idName.ToLower()}.fxt", templatefxd);
                log.Info($"{info.idName.ToLower()}.fxt file generated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                log.Error($"Error on saving {info.idName.ToLower()}.fxt. Error:{ex.Message}");
                return false;            }
            #endregion

        }
    }
}
