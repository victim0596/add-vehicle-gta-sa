using addVehicle.Const;
using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;
using addVehicle.generatorLine.Contract;

namespace addVehicle.generatorLine.Concrete
{
    public class GenModFile : IGenMod
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<bool> genAndSave(Info info)
        {
            log.Info("Starting copying and renaming of dff and txt file of vehicle.");
            bool dffCheck = false;
            bool txdCheck = false;
            #region save on modloader folder
            try
            {

                using (FileStream SourceStream = File.Open(info.dffVehicle.path, FileMode.Open))
                {
                    using (FileStream DestinationStream = File.Create($"{info.modFolder}\\{info.idName.ToLower()}.dff"))
                    {
                        await SourceStream.CopyToAsync(DestinationStream);
                        log.Info($"{info.idName.ToLower()}.dff generated successfully.");
                        dffCheck = true;
                    }
                }

                using (FileStream SourceStream = File.Open(info.txdVehicle.path, FileMode.Open))
                {
                    using (FileStream DestinationStream = File.Create($"{info.modFolder}\\{info.idName.ToLower()}.txd"))
                    {
                        await SourceStream.CopyToAsync(DestinationStream);
                        log.Info($"{info.idName.ToLower()}.txd generated successfully.");
                        txdCheck = true;
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error($"Error on copying and renaming the dff and txt. Error:{ex.Message}");
                return false;
            }
            return dffCheck && txdCheck;
            #endregion
        }
    }
}
