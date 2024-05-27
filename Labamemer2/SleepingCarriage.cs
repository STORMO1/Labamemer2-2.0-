using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labamemer2
{
    public class SleepingCarriage : Carriage
    {
        public int CompartmentsCount { get; set; }
        public bool HasShowers { get; set; }
        public bool HasDoors { get; set; }

        public SleepingCarriage(string id, string type, double weight, double length, int number, int compartmentsCount, bool hasShowers, bool hasDoors)
            : base(id, type, weight, length, number)
        {
            CompartmentsCount = compartmentsCount;
            HasShowers = hasShowers;
            HasDoors = hasDoors;
        }

        public int CheckSleepingPeople()
        {
            Random random = new Random();
            int sleepingPeople = random.Next(0, CompartmentsCount + 1);
            Console.WriteLine($"У вагоні {Id} спить {sleepingPeople} людей.");
            return sleepingPeople;
        }

        public bool CheckShowers()
        {
            if (HasShowers)
            {
                Console.WriteLine($"У вагоні {Id} є душова кабіна.");
                return true;
            }
            else
            {
                Console.WriteLine($"У вагоні {Id} немає душової кабіни.");
                return false;
            }
        }
        public bool CheckDoorsInCompartments()
        {
            if (HasDoors)
            {
                Console.WriteLine($"У вагоні {Id} є двері у купе.");
                return true;
            }
            else
            {
                Console.WriteLine($"У вагоні {Id} немає дверей у купе.");
                return false;
            }
        }
    }

}
