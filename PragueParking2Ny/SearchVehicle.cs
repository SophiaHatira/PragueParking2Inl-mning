using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class SearchVehicle
    {
        // Regnummer skrivs in för att se vart fordon står parkerat
        public static bool SearchForVehicle(string regnumber) 
        {

            (Vehicle Foundvehicle, ParkingSpot spot) = ParkingGarage.FindVehicleSpot(regnumber);
            if (Foundvehicle != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehicle located, {0}:{3} and is parked on spot:{1}. Park time startad at: {2}", Foundvehicle.VehType, Foundvehicle.ParkedOnSpot, Foundvehicle.ParkTime.ToString("g"), Foundvehicle.RegNumber);
                Console.ReadKey();
                Console.ResetColor();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vehicle not found. Entered input: {0}. Please make sure your input is correct!", regnumber);
                Console.ReadKey();
                Console.ResetColor();
                return false;
            }


        }
    }
}

