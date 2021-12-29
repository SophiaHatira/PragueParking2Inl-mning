using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class RemoveVehicle
    {
        // Tar ut sitt fordon, och all information om fordonet visas
        public static void CheckoutVehicle(string regNumber) 
        {
            (Vehicle foundVehicle, ParkingSpot spot) = ParkingGarage.FindVehicleSpot(regNumber);
            if (spot != null)
            {
                if (foundVehicle.VehType is not "buss")
                {
                    int vehCost = foundVehicle.vehCost;
                    spot.ParkingSpotSize += foundVehicle.VehSize;
                    string ParkTime = foundVehicle.ParkTime.ToString();
                    ParkingSpot.RemoveVehicle(foundVehicle, spot);
                    Config.SaveToJasonFile();
                    string checkin = foundVehicle.ParkTime.ToString();
                    int CalculatePrice = ParkingSpot.CalculateTimeParked(checkin, foundVehicle);
                    recipt(foundVehicle, CalculatePrice, out string removed);
                }
                
            }
            else
            {
                ParkingGarage.ErrorMsg();
            }
        }
        // Här visas parkeringsplats, tid & pris 
        public static void recipt(Vehicle vehicle, int totalPrice, out string recpit) 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            recpit = $"Removing vehicle {vehicle.RegNumber} from spot {vehicle.ParkedOnSpot} Parking was started at {vehicle.ParkTime} And was parked till {DateTime.Now}. Price To pay:{totalPrice}CZK";
            Console.WriteLine(recpit);
            Console.ReadKey();
            Console.ResetColor();

        }
    }
}
    
