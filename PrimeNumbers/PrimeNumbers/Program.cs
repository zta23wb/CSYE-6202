using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many prime numbers do you want to find?");
            int input = -1;
            int sum = 0;    //keep track of the sum of the prime numbers
            int N = 0;    //keep track of how many prime numbers have been found
            try
            {
                input = Int32.Parse(Console.ReadLine());
                if (input >= 0)
                {
                    int foundedPrimeNumbers = findPrimeNumbers(N, input, sum);
                    Console.WriteLine("The first " + input + " prime numbers' sum is " + foundedPrimeNumbers);
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer");
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("Please enter a valid integer");
            }catch(OverflowException e)
            {
                Console.WriteLine("Please enter a positive integer that is less than " + Int32.MaxValue);
            }
            Console.ReadLine();
        }

        static int findPrimeNumbers(int N, int input, int sum)
        {
            int numberCheck = 2;
            bool isPrimeNumber = true;
            while(N < input)
            {
                for(int i = 2; i <= numberCheck - 1; i++)
                {
                    if(numberCheck % i == 0)
                    {
                        isPrimeNumber = false;
                    }
                    if(i >= numberCheck)
                    {
                        isPrimeNumber = true;
                    }
                }
                if(isPrimeNumber == true)
                {
                    N++;
                    sum += numberCheck;
                }else
                {
                    isPrimeNumber = true;
                }
                numberCheck++;
            }
            return sum;
        }
    }
}
