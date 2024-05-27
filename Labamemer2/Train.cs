using System;
using System.Collections.Generic;

namespace Labamemer2
{
    public class Train
    {
        public LinkedList<Carriage> Carriages { get; private set; }
        public string Name { get; set; }
        public string RouteNumber { get; set; }

       
        public Train(string name, string routeNumber)
        {
            Carriages = new LinkedList<Carriage>();
            Name = name;
            RouteNumber = routeNumber;
        }

       
        public void AddCarriage(Carriage carriage, int? position = null)
        {
            
            if (position == null)
            {
                Carriages.AddLast(carriage);
            }
            else
            {
                
                var node = Carriages.First;
                for (int i = 0; i < position && node != null; i++)
                {
                    node = node.Next;
                }
                if (node != null)
                {
                    Carriages.AddBefore(node, carriage);
                }
                else
                {
                    Carriages.AddLast(carriage);
                }
            }
        }

       
        public void RemoveCarriage(int? position = null)
        {
     
            if (position == null)
            {
                Carriages.RemoveLast();
            }
            else
            {
                
                var node = Carriages.First;
                for (int i = 0; i < position && node != null; i++)
                {
                    node = node.Next;
                }
                if (node != null)
                {
                    Carriages.Remove(node);
                }
            }
        }

        
        public IEnumerable<Carriage> FindCarriagesByCriteria(Func<Carriage, bool> criteria)
        {
            
            foreach (var carriage in Carriages)
            {
                if (criteria(carriage))
                {
                    yield return carriage;
                }
            }
        }

        
        public double CalculateTotalWeight()
        {
            double totalWeight = 0;
            foreach (var carriage in Carriages)
            {
                totalWeight += carriage.Weight;
            }
            return totalWeight;
        }

        
        public void PrintAllCarriagesInfo()
        {
            foreach (var carriage in Carriages)
            {
                Console.WriteLine($"ID: {carriage.Id}, Type: {carriage.Type}, Weight: {carriage.Weight}, Length: {carriage.Length}, Number: {carriage.Number}");
            }
        }

        
        public void ChangeRouteWhileInMotion(string Route)
        {
            Console.WriteLine("Вкажіть маршрут");
            Route = Console.ReadLine();
            RouteNumber = Route;
            Console.WriteLine($"Маршрут потягу змінено на {Route} під час руху.");
        }

        
        public void AddCarriageWhileInMotion(Carriage carriage, int? position = null)
        {
            AddCarriage(carriage, position);
            Console.WriteLine("Ви впевнені, що хочете додати вагон під час руху поїзду ? (1.так 2.ні)");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.WriteLine("Вагон приєднано до потягу під час руху.");
            }
            else
            {
                Console.WriteLine("Вагон не було приєднано до потягу під час руху.");
            }
            
        }

        
        public void RemoveCarriageWhileInMotion(int? position = null)
        {
            RemoveCarriage(position);
            Console.WriteLine("Ви впевнені, що хочете видалити вагон під час руху поїзду ? (1.так 2.ні)");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.WriteLine("Вагон видалено з потягу під час руху.");
            }
            else
            {
                Console.WriteLine("Вагон не було видалено з потягу.");
            }
        }
        public IEnumerable<Carriage> FindCarriagesByType(string type)
        {
 
            foreach (var carriage in Carriages)
            {
                if (carriage.Type == type)
                {
                    yield return carriage;
                }
            }
        }
        public IEnumerable<Carriage> FindCarriagesByCargoCapacity(double minCapacity, double maxCapacity)
        {
            
            foreach (var carriage in Carriages)
            {
                if (carriage is FreightCarriage freightCarriage)
                {
                    if (freightCarriage.MaxLoadCapacity >= minCapacity && freightCarriage.MaxLoadCapacity <= maxCapacity)
                    {
                        yield return carriage;
                    }
                }
            }
        }
        public IEnumerable<PassengerCarriage> FindCarriagesWithFreeSeats(int minFreeSeats)
        {
            
            foreach (var carriage in Carriages)
            {
                if (carriage is PassengerCarriage passengerCarriage)
                {
                    if (passengerCarriage.SeatsCount - passengerCarriage.PassengersCount >= minFreeSeats)
                    {
                        yield return passengerCarriage;
                    }
                }
            }
        }
        public int CalculateTotalPassengersCount()
        {
            int totalPassengersCount = 0;
            foreach (var carriage in Carriages)
            {
                if (carriage is PassengerCarriage passengerCarriage)
                {
                    totalPassengersCount += passengerCarriage.PassengersCount;
                }
            }
            return totalPassengersCount;
        }
        public FreightCarriage FindCarriageWithMaxCargoCapacity()
        {
            FreightCarriage carriageWithMaxCapacity = null;
            double maxCapacity = 0;
            foreach (var carriage in Carriages)
            {
                if (carriage is FreightCarriage freightCarriage)
                {
                    if (freightCarriage.MaxLoadCapacity > maxCapacity)
                    {
                        maxCapacity = freightCarriage.MaxLoadCapacity;
                        carriageWithMaxCapacity = freightCarriage;
                    }
                }
            }
            return carriageWithMaxCapacity;
        }
        public Dictionary<string, int> CountCarriagesByType()
        {
            Dictionary<string, int> typeCounts = new Dictionary<string, int>();
            foreach (var carriage in Carriages)
            {
                string type = carriage.Type;
                if (typeCounts.ContainsKey(type))
                {
                    typeCounts[type]++;
                }
                else
                {
                    typeCounts[type] = 1;
                }
            }
            return typeCounts;
        }
        public bool HasHazardousCargoCarriages()
        {
            
            Random random = new Random();
            bool hasHazardousCargo = random.Next(2) == 1;

            
            if (hasHazardousCargo)
            {
                Console.WriteLine("Так, у поїзді є вагони для перевезення небезпечних матеріалів.");
                Console.WriteLine("Будьте обережні та дотримуйтесь правил безпеки при роботі з цими вагонами.");
                return true;
            }
            else
            {
                Console.WriteLine("Ні, у поїзді немає вагонів для перевезення небезпечних матеріалів.");
                return false;
            }
        }

    }

}


