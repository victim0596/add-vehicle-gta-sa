﻿using addVehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addVehicle.generatorLine.Contract
{
    public interface IGenLineLoader
    {
        public string genLinee(string linee, Info info, string fileAnalized);
    }
}
