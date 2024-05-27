using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labamemer2
{
    public class PassengerCarriage : Carriage
    {
        public int SeatsCount { get; set; }
        public string ComfortLevel { get; set; }
        public int PassengersCount { get; set; } 

        public PassengerCarriage(string id, string type, double weight, double length, int number, int seatsCount, string comfortLevel)
            : base(id, type, weight, length, number)
        {
            SeatsCount = seatsCount;
            ComfortLevel = comfortLevel;
            PassengersCount = 40;
        }

        public void DisembarkPassengers(int count)
        {
            if (count > PassengersCount)
            {
                throw new Exception("Помилка: намагаєтесь висадити більше пасажирів, ніж є в вагоні.");
            }

            PassengersCount -= count;
            Console.WriteLine($"Ви висадили {count} пасажирів з вагона №{Number}. Залишилося {PassengersCount} пасажирів.");
        }

        public bool AreThereFreeSeats(int count)
        {
         
            if (SeatsCount - PassengersCount >= count)
            {
                Console.WriteLine($"В вагоні є {SeatsCount - PassengersCount} вільних місць. Ви можете розмістити {count} пасажирів.");
                return true;
            }
            else
            {
                Console.WriteLine($"В вагоні немає вільних місць для {count} пасажирів. Доступно лише {SeatsCount - PassengersCount} вільних місць.");
                return false;
            }
        }


    }
}

