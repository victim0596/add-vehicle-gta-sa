using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addVehicle.generatorLine.Contract
{
    public interface IGenLineeOnLimitAdjuster
    {
        public Task<bool> genAndSave(Info info, Generator settings, string file);

    }
}
