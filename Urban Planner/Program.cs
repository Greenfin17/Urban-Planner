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
        static void AddPlan(ref List<Building> buildingList)
        {
            string address; 
            Console.WriteLine("               Enter building address:");
            Console.Write("               ");
            address = Console.ReadLine();
            Console.Write('\n');
            Building tempBuilding = new Building(address);
            buildingList.Add(tempBuilding);
        }

        static void ListBuildings(ref List<Building> buildingList)
        {
            for (int i = 0; i < buildingList.Count; i++)
            {
                buildingList[i].Status();
                Console.Write('\n');
            }
        }

        static void PurchaseBuilding(ref List<Building> buildingList)
        {
            ConsoleKeyInfo inputKey = new ConsoleKeyInfo();
            int buildingChoice;
            Console.WriteLine("               Select building to purchase:");
            for (int i = 0; i < buildingList.Count; i++)
            {
                Console.WriteLine($"               {i}) {buildingList[i].Address()}");
            }
            inputKey = Console.ReadKey(true);
            buildingChoice = (int) Char.GetNumericValue(inputKey.KeyChar);
            if( buildingChoice >= 0 && buildingChoice < buildingList.Count)
            {
                Console.WriteLine("               Enter name of purchaser:");
                Console.Write("               ");
               string input = Console.ReadLine();
                Console.WriteLine("               Purchasing the building.\n");
                buildingList[buildingChoice].Purchase(input);
            }
            else
            {
                Console.WriteLine("               Invalid choice.");
            }
        }

        static void ConstructBuilding(ref List<Building> buildingList)
        {
            ConsoleKeyInfo inputKey = new ConsoleKeyInfo();
            int buildingChoice;
            Console.WriteLine("               Select building to construct:");
            for (int i = 0; i < buildingList.Count; i++)
            {
                if (!buildingList[i].Constructed())
                {
                    Console.WriteLine($"               {i}) {buildingList[i].Address()}");
                }
            }
            inputKey = Console.ReadKey(true);
            buildingChoice = (int) Char.GetNumericValue(inputKey.KeyChar);
            if( buildingChoice >= 0 && buildingChoice < buildingList.Count)
            {
                string input;
                int stories = 0;
                int number;
                double dblNumber;
                double width = 0.0;
                double depth = 0.0;
                bool valid = true;
                Console.WriteLine("               Enter the number of stories:");
                Console.Write("               ");
                input = Console.ReadLine();
                if (Int32.TryParse(input, out number))
                {
                    stories = number;
                }
                else valid = false;
                
                Console.WriteLine("               Enter the building width:");
                Console.Write("               ");
                input = Console.ReadLine();
                if (double.TryParse(input, out dblNumber))
                {
                    width = dblNumber;
                }
                else valid = false;
                
                Console.WriteLine("               Enter the building depth:");
                Console.Write("               ");
                input = Console.ReadLine();
                if (double.TryParse(input, out dblNumber))
                {
                    depth = dblNumber;
                }
                else valid = false;

                if (valid)
                {
                    if (buildingList[buildingChoice].Construct(stories, width, depth))
                    {
                        Console.WriteLine("               Constructing the building.");
                    } else
                    {
                        Console.WriteLine("               This building has already been constructed.");

                    }
                }
            } else
            {
                Console.WriteLine("               Invalid choice.");
            }
            Console.Write('\n');
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo InputKey = new ConsoleKeyInfo();
            bool exit = false;
            List<Building> buildings = new List<Building>();

            Console.WriteLine("\n\n               Welcome to the Urban Planner\n");
            while (!exit)
            {
                Console.WriteLine("               Select option:");
                Console.WriteLine("               1) Create building plan:");
                Console.WriteLine("               2) Construct building:");
                Console.WriteLine("               3) Purchase building:");
                Console.WriteLine("               4) List buildings:");
                Console.WriteLine("               x) Exit:");

                InputKey = Console.ReadKey(true);
                Console.Write("\n");
                switch (InputKey.KeyChar)
                {
                    case '1':
                        AddPlan(ref buildings);
                        break;
                    case '2':
                        ConstructBuilding(ref buildings);
                        break;
                    case '3':
                        PurchaseBuilding(ref buildings);
                        break;
                    case '4':
                        ListBuildings(ref buildings);
                        break;
                    case 'x':
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
