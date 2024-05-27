using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labamemer2
{

    public abstract class Carriage
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public int Number { get; set; }

        public Carriage(string id, string type, double weight, double length, int number)
        {
            Id = id;
            Type = type;
            Weight = 55;
            Length = 25;
            Number = number;
        }
        
       
    }
}