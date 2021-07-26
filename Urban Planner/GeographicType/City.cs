using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urban_Planner.Structures;

namespace Urban_Planner.GeoEntity
{
    class City
    {
        public string Name { get; set; }
        public string Mayor { get; set; }
        public DateTime Established { get; set; }
        public List<Building> Buildings { get; set; }

        public City(string name, string mayor, DateTime established, List<Building> buildings)
        {
            Name = name;
            Mayor = mayor;
            Established = established;
            Buildings = buildings;
        }

        public void Status()
        {
            Console.WriteLine($"               {Name}");
            Console.WriteLine($"               Mayor: {Mayor}");
            Console.WriteLine($"               Established: {Established.ToShortDateString()}\n");
            foreach(var building in Buildings)
            {
                building.Status();
                Console.Write('\n');
            }
        }
    }
}
