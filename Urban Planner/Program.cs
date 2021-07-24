using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urban_Planner.Structures;

namespace Urban_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo inputKey = new ConsoleKeyInfo();
            bool exit = false;
            List<Building> buildings = new List<Building>();

            Console.WriteLine("\n\n               Welcome to the Urban Plannerl\n");
            while (!exit)
            {
                Console.WriteLine("               Select option:");
                Console.WriteLine("               1) Create building plan:");
                Console.WriteLine("               2) Construct building:");
                Console.WriteLine("               3) Purchase building:");
                Console.WriteLine("               4) List buildings:");
                Console.WriteLine("               x) Exit:");

                inputKey = Console.ReadKey(true);
                Console.Write('\n');
                if (inputKey.KeyChar == 'x')
                {
                    exit = true;
                }
            }

            string[] purchasers = new string[] { "Art Linkletter", "Bob Ross", "Homer Simpson", "Mr. Burns" };

            Console.WriteLine("\n\n               Welcome to the Urban Plannerl\n");
            Console.WriteLine("               Creating Building Plans....");
            Building OneTwelveBroad = new Building("112 Broadway");
            Building OneTenChurch = new Building("110 Church St.");
            Building SevenTwelveFourth = new Building("712 Fourth Ave. South");
            Building OneTwentyBroad = new Building("120 Broadway");


            Console.WriteLine($"               Constructing {OneTwelveBroad.Address()}");
            OneTwelveBroad.Construct(20, 50.0, 75.0);
            buildings.Add(OneTwelveBroad);
            Console.WriteLine($"               Constructing {OneTenChurch.Address()}");
            OneTenChurch.Construct(15, 45.0, 65.0);
            buildings.Add(OneTenChurch);
            Console.WriteLine($"               Constructing {SevenTwelveFourth.Address()}");
            SevenTwelveFourth.Construct(40, 75.0, 130.0);
            buildings.Add(SevenTwelveFourth);
            Console.WriteLine($"               Constructing {OneTwentyBroad.Address()}");
            OneTwentyBroad.Construct(35, 96.3, 140.7);
            buildings.Add(SevenTwelveFourth);

            for (int i = 0; i < buildings.Count; i ++)
            {
                Console.WriteLine($"               {purchasers[i]} is buying {buildings[i].Address()}");
                buildings[i].Purchase(purchasers[i]);
            }

            for (int i = 0; i < buildings.Count; i++)
            {
                buildings[i].Status();
                Console.Write('\n');
            }
            Console.WriteLine($"               Press any key to exit");
            inputKey = Console.ReadKey(true);

        }
    }
}
