﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addVehicle.Model;


namespace addVehicle.generatorLinee
{
    public class genCarcols
    {
        public Task<Generator> start(Info info)
        {
            return Task.FromResult(new Generator());
        }
    }
}
