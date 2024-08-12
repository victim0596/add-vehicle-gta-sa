using addVehicle.generatorLine.Contract;
using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addVehicle.generatorLine.Concrete
{
    public class GenLineLoader : IGenLineLoader
    {
        public string genLinee(string linee, Info info, string fileAnalized)
        {
            string lineeToReturn = linee;
            switch (fileAnalized)
            {
                case "handling.cfg":
                    {
                        lineeToReturn = lineeToReturn.Replace(info.nameVehicleToCopy, info.idName.ToUpper());
                        break;
                    }
                case "carcols.dat":
                case "carmods.dat":
                case "gtasa_vehicleAudioSettings.cfg":
                    {
                        lineeToReturn = lineeToReturn.Replace(info.nameVehicleToCopy.ToLower(), info.idName.ToLower());
                        break;
                    }
                case "vehicles.ide":
                    {
                        IList<string> lines = lineeToReturn.Split(",").ToList();
                        lines[0] = info.id.ToString();
                        lines[1] = info.idName.ToLower();
                        lines[2] = info.idName.ToLower();
                        lines[4] = info.idName.ToUpper();
                        lines[5] = info.idName.ToUpper();
                        lineeToReturn = string.Join(",", lines);
                        break;
                    }
            }
            return lineeToReturn;
        }
    }
}
