using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace PragueParking2._0
{
    public class Mainmenu
    {
        // Huvud menyn som visar kunden de olika alternativen
        public static void MainMenu() 
        {
            string menuChoice;

            do
            {
                Console.Clear();
                var table = new Table();
                table.AddColumn("PRAGUE PARKING 2.0").Centered();

                AnsiConsole.Write(table);
                ParkingGarage.PrintParkingLot();
                menuChoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                  .AddChoices(new[] { "Park vehicle", "Remove Vehicle", "Move Vehicle", "Parked Vehicles", "Search Vehicle", "Clear parkinglot", "Exit Program" }));

                if (menuChoice == "Exit Program") 
                {
                    Environment.Exit(1);
                }
                if (menuChoice == "Parked Vehicles") 
                {
                    ParkingGarage.PrintParkingLot();
                    ParkingSpot.ShowVehicles();
                }
                if (menuChoice == "Clear parkinglot") 
                {
                    ParkingGarage.ClearParkinglot();

                }
                else if (ParkVehicle.ValidRegnum(out string licensplate))
                {
                    switch (menuChoice)
                    {
                        case "Park vehicle":

                            menuChoice = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(new[] { "CAR", "MC" })); 
                            if (menuChoice == "CAR")
                            {
                                ParkVehicle.AddVehicle(menuChoice, licensplate);
                            }
                            else
                            {
                                ParkVehicle.AddVehicle(menuChoice, licensplate);
                            }
                            break;
                        case "Remove Vehicle":
                            RemoveVehicle.CheckoutVehicle(licensplate);
                            break;
                        case "Move Vehicle":
                            MoveVehicle.Move(licensplate);
                            break;
                        case "Search Vehicle":
                            SearchVehicle.SearchForVehicle(licensplate);
                            break;
                    }
                }
                else
                {
                    ParkingGarage.ErrorMsg(); // Visar felmeddelande
                }

            } while (menuChoice != "Exit Program");
        }
    }
}






