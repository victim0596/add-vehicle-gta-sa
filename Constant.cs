﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;

namespace addVehicle
{
    public static class Constant
    {
        public static IList<string> _vehicleList = new List<string>()
        {
            //car
            "LANDSTAL","BRAVURA","BUFFALO","LINERUN","PEREN","SENTINEL","DUMPER","FIRETRUK","TRASH","STRETCH","MANANA","INFERNUS","VOODOO","PONY","MULE","CHEETAH","AMBULAN","MOONBEAM","ESPERANT","TAXI","WASHING","BOBCAT","MRWHOOP","BFINJECT","PREMIER","ENFORCER","SECURICA","BANSHEE","BUS","RHINO","BARRACKS","HOTKNIFE","ARTICT1","PREVION","COACH","CABBIE","STALLION","RUMPO","RCBANDIT","ROMERO","PACKER","MONSTER","ADMIRAL","TRAM","AIRTRAIN","ARTICT2","TURISMO","FLATBED","YANKEE","GOLFCART","SOLAIR","GLENDALE","OCEANIC","PATRIOT","HERMES","SABRE","ZR350","WALTON","REGINA","COMET","BURRITO","CAMPER","BAGGAGE","DOZER","RANCHER","FBIRANCH","VIRGO","GREENWOO","HOTRING","SANDKING","BLISTAC","BOXVILLE","BENSON","MESA","BLOODRA","BLOODRB","SUPERGT","ELEGANT","JOURNEY","PETROL","RDTRAIN","NEBULA","MAJESTIC","BUCCANEE","CEMENT","TOWTRUCK","FORTUNE","CADRONA","FBITRUCK","WILLARD","FORKLIFT","TRACTOR","COMBINE","FELTZER","REMINGTN","SLAMVAN","BLADE","FREIGHT","STREAK","VINCENT","BULLET","CLOVER","SADLER","RANGER","HUSTLER","INTRUDER","PRIMO","TAMPA","SUNRISE","MERIT","UTILITY","YOSEMITE","WINDSOR","MTRUCK_A","MTRUCK_B","URANUS","JESTER","SULTAN","STRATUM","ELEGY","RCTIGER","FLASH","TAHOMA","SAVANNA","BANDITO","FREIFLAT","CSTREAK","KART","MOWER","DUNE","SWEEPER","BROADWAY","TORNADO","DFT30","HUNTLEY","STAFFORD","NEWSVAN","TUG","PETROTR","EMPEROR","FLOAT","EUROS","HOTDOG","CLUB","ARTICT3","POLICE_LA","POLICE_SF","POLICE_VG","POLRANGER","PICADOR","SWATVAN","ALPHA","PHOENIX",
            //bike
            "BIKE","MOPED","DIRTBIKE","FCR900","NRG500","HPV1000","BF400","WAYFARER","QUADBIKE","BMX","CHOPPERB","MTB","FREEWAY",
            //plane
            "SEAPLANE","VORTEX","RUSTLER","BEAGLE","CROPDUST","STUNT","SHAMAL","HYDRA","NEVADA","AT400","ANDROM","DODO","SPARROW","SEASPAR","MAVERICK","COASTMAV","POLMAV","HUNTER","LEVIATHN","CARGOBOB",
            //boat
            "PREDATOR","SPEEDER","REEFER","RIO","SQUALO","TROPIC","COASTGRD","DINGHY","MARQUIS","CUPBOAT","LAUNCH"

        };
        public static IList<string> _typeVehicleList = new List<string>()
        {
            "Car", "Bike/Motorcycle", "Aeroplane", "Boat"
        };
        public static string _typeCar = "Car";
        public static string _typeBike = "Bike/Motorcycle";
        public static string _typeAero = "Aeroplane";
        public static string _typeBoat = "Boat";

    }
}
