using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class ParkVehicle
    {
        // Kontrollerar att regnr är giltigt
        public static bool ValidRegnum(out string aregnumber) 
        {
            Console.WriteLine("Enter licenseplate:");
            string regnumber = Console.ReadLine().ToUpper();

            Regex reg = new Regex(@"^[\w\d-]{4,10}$");
            MatchCollection matches = reg.Matches(regnumber);
            if (matches.Count > 0)
            {
                aregnumber = regnumber;
                return true;
            }
            else
            {
                aregnumber = regnumber;
                return false;
            }
        }

        // Skapar bil eller MC
        public static void AddVehicle(string type, string regnumber)
        {
            (Vehicle found, ParkingSpot spot) = ParkingGarage.FindVehicleSpot(regnumber);
            if (found == null)
            {
                if (ParkingGarage.CheckparkingLotSpace() != null)
                {
                    if (type == "CAR")
                    {
                        Car newcar = new Car(regnumber);
                        spot = ParkingSpot.SpotFinder(newcar.VehSize);
                        spot.ParkingSpotSize -= newcar.VehSize;
                        ParkingSpot.ParkVehicle(newcar, spot);
                        Recipt(newcar, spot, out string recipt);
                        Config.SaveToJasonFile();
                    }
                    else if (type == "MC")
                    {
                        MC newmc = new MC(regnumber);
                        spot = ParkingSpot.SpotFinder(newmc.VehSize);
                        spot.ParkingSpotSize -= newmc.VehSize;
                        ParkingSpot.ParkVehicle(newmc, spot);
                        Recipt(newmc, spot, out string recipt);
                        Config.SaveToJasonFile();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The parkinglot is full. we cant park anymore vehicles with that size");
                    Console.ReadLine();
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An issue occured. Please confirm the size of parking garage and make sure your car fits! Or, the parking garage could be at maximum capacity. Please try again or come back another day!");
                Console.ReadKey();
                Console.ResetColor();
            }

        }

        // Skapar ett kvitto
        public static void Recipt(Vehicle vehicle, ParkingSpot spot, out string recipt)  
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            recipt = $"Parking vehicle {vehicle.RegNumber} at parkingspace {spot.SpotNumber} parking started at :{vehicle.ParkTime.ToString("G")}";
            Console.WriteLine(recipt);
            Console.ReadKey();
            Console.ResetColor();
        }

    }
}
