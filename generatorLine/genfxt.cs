using addVehicle.Const;
using addVehicle.Model;
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
        public bool genAndSave(Info info)
        {
            string templatefxd = template.templateFxd.Replace("{vehicleNameId}", info.idName.ToUpper()).Replace("{visualVehicleName}", info.visualName);
            #region save on modloader folder
            File.WriteAllText($"{info.modFolder}\\name.fxt", templatefxd);
            #endregion
            return true;
        }
    }
}
