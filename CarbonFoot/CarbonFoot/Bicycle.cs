using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Bicycle : Artificials
    {


        public Bicycle(double keyFactor)
        {
            this.Name = "Bicycle";
            this.KeyFactor = keyFactor;
            this.MultiployFactor = 0.0;
        }


        public override double CalculateCarbonFootprint()
        {
            return KeyFactor * MultiployFactor;
        }
    }
}
