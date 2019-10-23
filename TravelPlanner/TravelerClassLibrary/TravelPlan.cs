using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelPlanner;

namespace TravelerClassLibrary
{
    public class TravelPlan
    {
        public List<Traveler> plan;

        public TravelPlan(List<Traveler> plan)
        {
            this.plan = plan;
        }

        public string findNext(string from, string to, string start)
        {
            Console.WriteLine(start);
            Traveler t = findCity(from,to);
            if (t != null)
            {
                times time = findTime(t, to, start);
                if(time != null)
                {
                    return "{ depart: " + from + ", departureTime: " + time.Leave + ", arrive: " + to + ", arrivalTime: " + time.Arrive + " }";
                }
                
            }
            return "";
        }

        public Traveler findCity(string from, string to)
        {
            foreach (var p in plan)
            {
                if (p.City == from)
                {
                    return p;
                }
                if( from == "Linz" && p.City == to)
                {
                    return p;
                }
            }
            return null;
        }

        public times findTime(Traveler t, string to, string start)
        {
            times time;
            if (to != "Linz")
            {
                time = compareTime(t.FromLinz,start); 
            }
            else
            {
                time = compareTime(t.ToLinz,start);
            }

            return time;
            
        }

        public times compareTime(List<times> times,string start)
        {
            
            foreach (var time in times)
            {
                int[] time_array = time.Leave.Split(':').Select(int.Parse).ToArray();
                int[] start_array = start.Trim().Split(':').Select(int.Parse).ToArray();
                Console.WriteLine(time_array[0] +" "+start_array[0]);
                if(time_array[0] >=start_array[0] && time_array[1] >= start_array[1])
                {
                    return time;
                }
            }
            return null;
        }
    }
}
