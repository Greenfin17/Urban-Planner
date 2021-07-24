using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urban_Planner.Structures
{
    class Building
    {
        public int Stories { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Volume { get; private set; }

        string _designer;
        DateTime _dateConstructed;
        string _address;
        string _owner;

        public Building(string address)
        {
            _address = address;
            _designer = "Bob Ross";
            _dateConstructed = DateTime.MinValue;
            _owner = null;
            Width = 0.0;
            Depth = 0.0;
            Stories = 0;
            Volume = 0;
        }

        public bool Construct(int stories, double width, double depth)
        {
            bool returnVal = false;
            if (_dateConstructed == DateTime.MinValue)
            {
                _dateConstructed = DateTime.Now;
                Stories = stories;
                Width = width;
                Depth = depth;
                Volume = Width * Depth * (3 * Stories);
                returnVal = true;
            }
            return returnVal;
        }

        public void Purchase(string purchaser)
        {
            _owner = purchaser;
        }

        public void Status()
        {
            Console.WriteLine($"               {_address} Designed by {_designer}");
            if (_dateConstructed != DateTime.MinValue)
            {
                Console.WriteLine($"               Consructed on {_dateConstructed}");
            }
            else
            {
                Console.WriteLine($"               This building has not yet been constructed.");

            }
            if (_owner != null)
            {
                Console.WriteLine($"               Owned by {_owner}");

            }
            else
            {
                Console.WriteLine($"               This building has not been purchased.");
            }
            if (_dateConstructed != DateTime.MinValue)
            {
                Console.WriteLine($"               {Volume} cubic meters of space.");
            }

        }
        public string Address()
        {
            return _address;
        }
    }
}
