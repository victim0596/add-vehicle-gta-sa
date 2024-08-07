using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genConf.generatorLinee
{
    public class mainGenerator
    {
        public async Task<bool> start() 
        {
            genHandling genHandling = new genHandling();
            bool checkGenHandling = await genHandling.start();

            genCarcols genCarcols = new genCarcols();
            bool checkgenCarcols = await genCarcols.start();

            genCargrp genCargrp = new genCargrp();
            bool checkgenCargrp = await genCargrp.start();

            genCarMods genCarMods = new genCarMods();
            bool checkgenCarMods = await genCarMods.start();

            genVehicles genVehicles = new genVehicles();
            bool checkgenVehicles = await genVehicles.start();

            return checkGenHandling;
        }
    }
}
