using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class MC : Vehicle
    {

        // Ger alla egenskaper till fordonet 
        public MC(string aRegNumber) : base(aRegNumber)
        {

            VehSize = Config.McSize; 
            VehType = "MC";
            ParkTime = DateTime.Now;
            vehCost = Config.McPrice;
        }
        public MC(string aRegNumber, int spotNumber, DateTime parkTime) : base(aRegNumber)
        {
            ParkedOnSpot = spotNumber;
            VehSize = Config.CarSize;
            VehType = "MC";
            vehCost = Config.McPrice;
        }

    }
  }

