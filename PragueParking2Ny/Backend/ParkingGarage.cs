using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace PragueParking2._0
{
    class ParkingGarage
    {
        // Hämtar listan med alla platser 
        public static ParkingSpot[] ParkingSpots { get; set; } = new ParkingSpot[Config.ParkingLotSize];

        // Skapar en till lista som innehåller fordon
        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>(Config.ParkingLotSize); 
        public ParkingGarage()
        {
            GenerateParkinglot();
        }

        // Metoden för att skapa parkeringsplatser 
        public static void GenerateParkinglot() 
        {
            for (int i = 0; i < Config.ParkingLotSize; i++)
            {
                ParkingSpots[i] = (new ParkingSpot());
            }

        }

        // Metod som kontrollerar om parkeringsplats är ledig/finns fordon
        public static (Vehicle, ParkingSpot) FindVehicleSpot(string searchReg) 
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle.RegNumber == searchReg && spot.SpotNumber == vehicle.ParkedOnSpot)
                    {
                        return (vehicle, spot);
                    }
                    continue;
                }
            }
            return (null, null);

        }

        // Skapar en ny plats för fordon och parkerar fordonet på platsen
        public static ParkingSpot FreeSpot(int vehicleSize, int newSpot) 
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                if (spot.SpotNumber == newSpot)
                {
                    if (spot.ParkingSpotSize >= vehicleSize)
                    {
                        return spot;
                    }
                    return null;
                }
            }
            return null;
        }

        // Scannar av parkeringsplatsen
        public static ParkingSpot CheckparkingLotSpace() 
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                if (spot.ParkingSpotSize != 4)
                {
                    continue;
                }
                else
                {
                    return spot;
                }
            }
            return null;

        }

        // Används till MoveVehicle. Om fordon finns där, visas ett felmeddelande
        public static ParkingSpot FindParkedAtSpot(Vehicle vehcile) 
        {

            foreach (ParkingSpot spot in ParkingSpots)
            {
                if (spot.SpotNumber == vehcile.ParkedOnSpot)
                {
                    return spot;
                }
            }
            return null;
        }

        // Visar parkingsplatserna. Gul = Plats finns delvis(Mc ex)/innehåller fordon, Grön = tom plats, Röd = Full
        public static void PrintParkingLot()  
        {
            Table t1 = new Table();
            t1.AddColumns("[grey]EMPTY SPOT =[/] [green]GREEN[/]", "[grey]FULL SPOT =[/] [red]RED[/]", "[grey]HAlF FULL =[/] [yellow]YELLOW[/]").Centered().Alignment(Justify.Center);
            AnsiConsole.Write(t1);

            Table newTable = new Table().Centered();
            var parkingSpotColorMarking = String.Empty;
            var printResult = String.Empty;
            int emptySpots;

            for (int i = 0; i < Config.ParkingLotSize; i++)
            {
                if (ParkingGarage.ParkingSpots[i].ParkingSpotSize == 4)
                {
                    emptySpots = ParkingSpots[i].ParkingSpotSize;
                    
                    parkingSpotColorMarking = "green";
                }
                else if (ParkingGarage.ParkingSpots[i].ParkingSpotSize == 2)
                {
                    emptySpots = ParkingSpots[i].ParkingSpotSize;
                    parkingSpotColorMarking = "yellow";
                }

                else
                {
                    emptySpots = ParkingSpots[i].ParkingSpotSize;
                    parkingSpotColorMarking = "red";
                }

                printResult += ($"[{parkingSpotColorMarking}] {i + 1}[/] ");
            }
            newTable.AddColumn(new TableColumn(printResult));
            AnsiConsole.Write(newTable);
            var menu = new Table();
            menu.AddColumn(new TableColumn("Choose option below").Centered()).Alignment(Justify.Left);
            AnsiConsole.Write(menu);
        }

        // Skriver ut ett felmeddelande ifall kunden har skrivit fel
        public static void ErrorMsg() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect - Please make sure your input is correctly entered and please try again!");
            Console.ReadKey();
            Console.ResetColor();
        }

        // Rensar hela Listan
        public static void ClearParkinglot() 
        {
            Vehicles.Clear();
            foreach (ParkingSpot spot in ParkingSpots)
            {
                spot.ParkingSpotSize = Config.ParkingspotSize;
            }
        }
    }
}



