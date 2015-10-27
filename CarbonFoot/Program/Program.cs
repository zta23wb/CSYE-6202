using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Artificials> artificialList = new List<Artificials>();


            Bicycle bicycleOne = new Bicycle(80.0);

            Car carOne = new Car(30.267);

            Building buildingOne = new Building(200000.27);

            artificialList.Add(bicycleOne);
            artificialList.Add(carOne);
            artificialList.Add(buildingOne);


            foreach (var artificials in artificialList)
            {
                Console.WriteLine("The Carbon Footprint of a {0} is {1}.", artificials.Name, artificials.CalculateCarbonFootprint());
            }


            Console.ReadKey();
        }
    }
}
