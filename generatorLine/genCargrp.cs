using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addVehicle.Model;


namespace addVehicle.generatorLinee
{
    public class genCargrp
    {
        public Task<Generator> start()
        {
            return Task.FromResult(new Generator());
        }
    }
}
