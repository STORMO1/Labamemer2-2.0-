
using System;
using System.Collections.Generic;
using Labamemer2;

namespace Labamemer2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Train train = new Train("Ластівка", "123-А");

           
            DiningCarriage diningCarriage = new DiningCarriage("D1", "Dining", 55, 25, 1, 10, true, 5, 100);
            FreightCarriage freightCarriage = new FreightCarriage("F2", "Freight", 60, 30, 2, 50, CargoType.Wood);
            PassengerCarriage passengerCarriage = new PassengerCarriage("P3", "Passenger", 50, 28, 3, 50, "Standard");
            SleepingCarriage sleepingCarriage = new SleepingCarriage("S4", "Sleeping", 65, 32, 4, 10, true, true);

            train.AddCarriage(diningCarriage);
            train.AddCarriage(freightCarriage);
            train.AddCarriage(passengerCarriage);
            train.AddCarriage(sleepingCarriage);

          
            train.PrintAllCarriagesInfo();

            
            Console.WriteLine("Введіть оцінку якості їжі у вагоні D1 (від 1 до 5):");
            int diningCarriageRating = int.Parse(Console.ReadLine());
            diningCarriage.EvaluateFood(diningCarriageRating);

            
            diningCarriage.CheckFoodStocks();

            Console.WriteLine("Введіть кількість зерна, яку потрібно завантажити у вагон F2:");
            double grainAmount = double.Parse(Console.ReadLine());
            freightCarriage.LoadUnloadCargo(grainAmount);

            
            Console.WriteLine("Введіть кількість пасажирів, яких ви хочете розмістити у вагоні P3:");
            int passengersCount = int.Parse(Console.ReadLine());
            passengerCarriage.AreThereFreeSeats(passengersCount);

            
            Console.WriteLine("Введіть кількість пасажирів, яких ви хочете висадити з вагона P3:");
            int disembarkCount = int.Parse(Console.ReadLine());
            passengerCarriage.DisembarkPassengers(disembarkCount);

        
            sleepingCarriage.CheckSleepingPeople();
            sleepingCarriage.CheckShowers();
            sleepingCarriage.CheckDoorsInCompartments();

            
            train.ChangeRouteWhileInMotion("456-Б");

      
            SleepingCarriage newSleepingCarriage = new SleepingCarriage("S5", "Sleeping", 70, 35, 5, 12, true, true);
            train.AddCarriageWhileInMotion(newSleepingCarriage, 2);

           
            train.RemoveCarriageWhileInMotion(1);

            
            IEnumerable<Carriage> passengerCarriages = train.FindCarriagesByCriteria(carriage => carriage.Type == "Passenger");
            Console.WriteLine("Вагони-пасажири:");
            foreach (var carriage in passengerCarriages)
            {
                Console.WriteLine(carriage.Id);
            }
           
            IEnumerable<Carriage> freightCarriages = train.FindCarriagesByCargoCapacity(40, 60);
            Console.WriteLine("Вагони-фургони (вантажність 40-60 тонн):");
            foreach (var carriage in freightCarriages)
            {
                Console.WriteLine(carriage.Id);
            }

            double totalWeight = train.CalculateTotalWeight();
            Console.WriteLine($"Загальна вага потягу: {totalWeight} тонн");

            
            IEnumerable<PassengerCarriage> freeSeatsCarriages = train.FindCarriagesWithFreeSeats(10);
            Console.WriteLine("Пасажирські вагони (10+ вільних місць):");
            foreach (var carriage in freeSeatsCarriages)
            {
                Console.WriteLine(carriage.Id);
            }
            
            int totalPassengers = train.CalculateTotalPassengersCount();
            Console.WriteLine($"Загальна кількість пасажирів у поїзді: {totalPassengers}");

            
            FreightCarriage maxCapacityCarriage = train.FindCarriageWithMaxCargoCapacity();
            if (maxCapacityCarriage != null)
            {
                Console.WriteLine($"Вагон з найбільшою вантажопідйомністю: {maxCapacityCarriage.Id} (максимальна вантажопідйомність: {maxCapacityCarriage.MaxLoadCapacity} тонн)");
            }
            else
            {
                Console.WriteLine("У поїзді немає вагонів-фургонів.");
            }

            
            Dictionary<string, int> typeCounts = train.CountCarriagesByType();
            Console.WriteLine("Кількість вагонів кожного типу:");
            foreach (var pair in typeCounts)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
           
            bool hasHazardousCargo = train.HasHazardousCargoCarriages();
            if (hasHazardousCargo)
            {
                Console.WriteLine("У поїзді є вагони для перевезення небезпечних матеріалів.");
            }
            else
            {
                Console.WriteLine("У поїзді немає вагонів для перевезення небезпечних матеріалів.");
            }

        }
    }
}