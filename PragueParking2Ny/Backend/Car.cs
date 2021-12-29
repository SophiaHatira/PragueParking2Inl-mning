using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class Car : Vehicle // Ärver gemensamma egensakper som fordon har
    {

        public Car(string aRegNumber) : base(aRegNumber)
        {
            VehSize = Config.CarSize;
            VehType = "CAR";
            ParkTime = DateTime.Now;
            vehCost = Config.CarPrice;
        }
        public Car(string aRegNumber, int spotNumber, DateTime parkTime) : base(aRegNumber)
        {
            ParkedOnSpot = spotNumber;
            ParkTime = parkTime;
            VehSize = Config.CarSize;
            VehType = "CAR";
            ParkTime = parkTime;
            vehCost = Config.CarPrice;
        }
    }
}
