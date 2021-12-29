using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Spectre.Console;

namespace PragueParking2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.ReadSizeFile(); // Läser in parkeringsplateser
            ParkingGarage ParkingGarage = new ParkingGarage(); // Parkeringsgaraget
            Config.ReadParkingFile(); // Alla parkerade fordon
            Mainmenu.MainMenu(); // Kör menyn
        }
        
    }
}
