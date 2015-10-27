using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Car : Artificials
    {

        public Car(double keyFactor)
        {
            this.Name = "Car";
            this.KeyFactor = keyFactor;
            this.MultiployFactor = 20.0;
        }

        public override double CalculateCarbonFootprint()
        {
            return KeyFactor * MultiployFactor;
        }
    }
}
