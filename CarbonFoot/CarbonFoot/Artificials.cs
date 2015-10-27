using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public abstract class Artificials
    {
        public string Name { get; set; }
        public double KeyFactor { get; set; }
        public double MultiployFactor { get; set; }

        public abstract double CalculateCarbonFootprint();
    }
}
