using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addVehicle.generatorLine.Contract
{
    public interface ISaveFile
    {
        public Task<bool> save(IList<Generator> listGenerator, IList<Generator> listLimitAdjusterGenerator, Info info);
    }
}
