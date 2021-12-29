using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class MoveVehicle
    {
        // Metod för att flytta fordon
        public static bool Move(string regNumber)
        {
            Console.WriteLine("Enter new spot number:");
            string userInput = Console.ReadLine();
            int newSpot;
            bool check = int.TryParse(userInput, out newSpot);

            (Vehicle foundVehicle, ParkingSpot oldSpot) = ParkingGarage.FindVehicleSpot(regNumber);
            if (check && oldSpot != null)
            {
                ParkingSpot newSpots = ParkingGarage.FreeSpot(foundVehicle.VehSize, newSpot);

                if (newSpots != null)
                {
                    ParkingSpot.RemoveVehicle(foundVehicle, oldSpot);
                    ParkingSpot.ParkVehicle(foundVehicle, newSpots);
                    foundVehicle.ParkedOnSpot = newSpot;
                    newSpots.ParkingSpotSize -= foundVehicle.VehSize;
                    oldSpot.ParkingSpotSize += foundVehicle.VehSize;
                    Recipt(foundVehicle, newSpots, out string recipt);
                    Config.SaveToJasonFile();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Selected spot {0} is full. Please try again!", newSpots);
                    Console.ReadKey();
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("We could not find a vehicle with licenseplate {0} or the {1} is not an number", regNumber, userInput);
                Console.ReadKey();
                Console.ResetColor();
            }
            return true;

        }

        // Kvitto efter fordonet har flyttats
        public static void Recipt(Vehicle vehicle, ParkingSpot spot, out string recipt) 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            recipt = $"Move vehicle {vehicle.RegNumber} to parkingspace {spot.SpotNumber} you been parked for:{(DateTime.Now - vehicle.ParkTime).ToString("G")}";
            Console.WriteLine(recipt);
            Console.ReadKey();
            Console.ResetColor();
        }
    }
}
