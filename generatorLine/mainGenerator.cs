using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addVehicle.generatorLinee
{
    public class mainGenerator
    {
        public async Task<List<Generator>> start(Info info) 
        {
            List<Generator> list = new List<Generator>();
            genHandling genHandling = new genHandling();
            Generator checkGenHandling = await genHandling.start(info);
            list.Add(checkGenHandling);

            /*genCarcols genCarcols = new genCarcols();
            Generator checkgenCarcols = await genCarcols.start(info);
            list.Add(checkgenCarcols);

            genCargrp genCargrp = new genCargrp();
            Generator checkgenCargrp = await genCargrp.start(info);
            list.Add(checkgenCargrp);

            genCarMods genCarMods = new genCarMods();
            Generator checkgenCarMods = await genCarMods.start(info);
            list.Add(checkgenCarMods);

            genVehicles genVehicles = new genVehicles();
            Generator checkgenVehicles = await genVehicles.start(info);
            list.Add(checkgenVehicles);*/

            return list;
        }
    }
}
