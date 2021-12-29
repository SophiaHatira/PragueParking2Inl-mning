using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace PragueParking2._0
{
    // Egenskaper för parkingspot
    class ParkingSpot 
    {
        public static int seed = 1;

        public int ParkingSpotSize { get; set; } = Config.ParkingspotSize; // Hämtar antal parkeringsplatser 100st

        public int SpotNumber { get; }
        public string status { get; set; }


        public ParkingSpot()
        {

            this.ParkingSpotSize = Config.ParkingspotSize; 
            this.SpotNumber = seed;
            seed++;

        }

        // Lägger till fordon
        public static bool ParkVehicle(Vehicle vehicle, ParkingSpot spot) 
        {
            ParkingGarage.Vehicles.Add(vehicle);

            vehicle.ParkedOnSpot = spot.SpotNumber;

            return true;
        }

        // Letar efter en ledig plats
        public static ParkingSpot SpotFinder(int vehicleSize)
        {
            foreach (ParkingSpot spot in ParkingGarage.ParkingSpots)
            {
                if (spot.ParkingSpotSize >= vehicleSize)
                {
                    return spot;
                }
            }
            return null;
        }

        // Tar bort ett fordon
        public static void RemoveVehicle(Vehicle vehicle, ParkingSpot spot) 
        {
            ParkingGarage.Vehicles.Remove(vehicle);

        }

        // Visar alla fordon som är parkerade
        public static void ShowVehicles()
        {
            foreach (Vehicle vehicle in ParkingGarage.Vehicles)
            {
                Console.WriteLine("{0}:{1}: {2}: {3}, ", vehicle.ParkedOnSpot, vehicle.VehType, vehicle.RegNumber, vehicle.ParkTime);
            }
            Console.ReadKey();
        }

        // Räknar ut hur länge ett fordon har varit parkerat
        public static int CalculateTimeParked(string checkIn, Vehicle vehicle) 
        {
            TimeSpan span = DateTime.Now - vehicle.ParkTime;
            int totalPrice;
            if (span.TotalMinutes < 10)
            {
                totalPrice = 0;
            }
            else if (span.TotalMinutes < 125)
            {
                if (vehicle.VehType == "CAR")
                {
                    totalPrice = 20;
                }
                else
                {
                    totalPrice = 10;
                }
            }
            else
            {
                int hours;
                if (span.TotalMinutes - 10 % 60 == 0)
                {
                    hours = (int)(span.TotalMinutes - 10) / 60;
                }
                else
                {
                    hours = (int)(span.TotalMinutes - 10) / 60;
                    hours++;
                }
                if (vehicle.VehType == "CAR")
                {
                    totalPrice = hours * 20;
                }
                else
                {
                    totalPrice = hours * 10;
                }
            }
            return totalPrice;


        }
        }
    }
    

