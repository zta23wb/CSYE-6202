using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an integer");
            try {
                int inputNumber = Int32.Parse(Console.ReadLine());
                Console.WriteLine(parseFizzBuzz(inputNumber));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please input an integer");
            }
            catch(OverflowException e)
            {
                Console.WriteLine("Please input a value that is within the range of [" + Int32.MinValue + ", " + Int32.MaxValue + "]");
            }
            Console.ReadLine();
        }

        static String parseFizzBuzz(int N)
        {
            String returnParse = "" + N;
            if(N == 0) {
                return returnParse;
            }
            switch(N % 15)
            {
                case 0:
                    returnParse = "FizzBuzz";
                    break;
                case 3: case 6: case 9: case 12:
                    returnParse = "Fizz";
                    break;
                case 5: case 10:
                    returnParse = "Buzz";
                    break;
                default:
                    returnParse = "" + N;
                    break;
            }
            return returnParse;
        }
    }
}
