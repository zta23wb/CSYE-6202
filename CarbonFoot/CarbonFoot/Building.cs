using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Building : Artificials
    {

        public Building(double keyFactor)
        {
            this.Name = "Building";
            this.KeyFactor = keyFactor;
            this.MultiployFactor = 50.0;
        }

        public override double CalculateCarbonFootprint()
        {
            return KeyFactor * MultiployFactor;
        }
    }
}
