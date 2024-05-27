using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labamemer2
{

    
        public class DiningCarriage : Carriage
        {
            public int TablesCount { get; set; }
            public bool HasKitchen { get; set; }
            public int KitchenPersonnel { get; set; }
            public int FoodStocks { get; set; }

            public DiningCarriage (string id, string type, double weight, double length, int number, int tablesCount, bool hasKitchen, int kitchenPersonnel, int foodStocks)
                : base(id, type, weight, length, number)
            {
                TablesCount = tablesCount;
                HasKitchen = hasKitchen;
                KitchenPersonnel = kitchenPersonnel;
                FoodStocks = foodStocks;
            }

           
            public void EvaluateFood(int rating)
            {
                switch (rating)
                {
                    case 1:
                        Console.WriteLine($"Їжа у вагоні {Id} жахлива. Не рекомендується.");
                        break;
                    case 2:
                        Console.WriteLine($"Їжа у вагоні {Id} не дуже смачна. Можна знайти кращі варіанти.");
                        break;
                    case 3:
                        Console.WriteLine($"Їжа у вагоні {Id} нормальна. Можна поїсти, якщо немає інших варіантів.");
                        break;
                    case 4:
                        Console.WriteLine($"Їжа у вагоні {Id} смачна. Рекомендується.");
                        break;
                    case 5:
                        Console.WriteLine($"Їжа у вагоні {Id} чудова! Не пропустіть можливість спробувати.");
                        break;
                    default:
                        Console.WriteLine($"Неправильна оцінка якості їжі. Введіть число від 1 до 5.");
                        break;
                }
            }

            
            public void CheckFoodStocks()
            {
                if (FoodStocks > 0)
                {
                    Console.WriteLine($"У вагоні {Id} ще є {FoodStocks} порцій їжі.");
                }
                else
                {
                    Console.WriteLine($"У вагоні {Id} закінчилася їжа. Потрібно поповнити запаси.");
                }
            }
        }

    
}
