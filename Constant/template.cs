using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addVehicle.Const
{
    public static class template
    {
        public static string templateLoader = @"
[Handling cfg]

{handling.cfg}


[Vehicles Ide]

{vehicles.ide}


[Carcols dat]

{carcols.dat}


[Carmods dat]

{carmods.dat}

";
        public static string templateFxd = "{vehicleNameId} {visualVehicleName}";

    }
}
