using addVehicle.Const;
using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace addVehicle.generatorLine
{
    public class GenModFile
    {
        public bool genAndSave(Info info)
        {
            #region save on modloader folder
            //dff
            File.Copy(info.dffVehicle.path, $"{info.modFolder}\\{info.idName.ToLower()}.dff");
            //txd
            File.Copy(info.txdVehicle.path, $"{info.modFolder}\\{info.idName.ToLower()}.txd");
            #endregion
            return true;
        }
    }
}
