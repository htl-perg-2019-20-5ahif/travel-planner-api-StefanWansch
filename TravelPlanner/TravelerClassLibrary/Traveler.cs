using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public class Traveler
    {
        public string City { get; set; }
        public List<times> ToLinz { get; set; }
        public List<times> FromLinz { get; set; }

    }


    public class times
    {
        public string Leave { get; set; }
        public string Arrive { get; set; }

        public string toString()
        {
            return Leave + " " + Arrive;
        }
    }
}
