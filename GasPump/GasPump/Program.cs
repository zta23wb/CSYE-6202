using System;

namespace GasPump
{
	public class Program
	{
		public enum GasType
		{
			None,
			RegularGas,
			MidgradeGas,
			PremiumGas,
			DieselFuel				
		}

		static void Main(string[] args)
		{
            // your implementation here
            String userInput = "";
            double totalCost = -1.1;
            do
            {
                Console.WriteLine("Please enter purchased gas type, Q/q to quit: ");
                userInput = Console.ReadLine();
                if(UserEnteredSentinelValue(userInput) == true)
                {
                    break;
                }
                if(UserEnteredValidGasType(userInput) == false)
                {
                    continue;
                }
                GasType wantedGasType = GasTypeMapper(userInput[0]);
                while (UserEnteredValidAmount(userInput) == false)
                {
                    Console.WriteLine("Please enter purchased gas amount, Q/q to quit: ");
                    userInput = Console.ReadLine();
                    if (UserEnteredSentinelValue(userInput) == true)
                    {
                        break;
                    }
                    if(UserEnteredValidAmount(userInput) == false)
                    {
                        continue;
                    }
                    double gasAmount = Convert.ToDouble(userInput);
                    Console.WriteLine("You bought " + gasAmount + " gallons of " + wantedGasType + " at $" + GasPriceMapper(wantedGasType));
                    CalculateTotalCost(wantedGasType, (int) gasAmount, ref totalCost);
                    break;
                }
                continue;
            } while (UserEnteredSentinelValue(userInput) == false);
            Console.WriteLine("Application terminated");
            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey();
		}

		// use this method to check and see if sentinel value is entered
		public static bool UserEnteredSentinelValue(string userInput)
		{
			var result = false;

            // your implementation here
            if(String.IsNullOrEmpty(userInput) == false)
            {
                if(Char.ToUpper(userInput[0]) == 'Q')
                {
                    return true;
                }
            }

			return result;
		}

		// use this method to parse and check the characters entered
		// this does not conform 
		public static bool UserEnteredValidGasType(string userInput)
		{
			var result = false;

            // your implementation here
            if(String.IsNullOrEmpty(userInput) == true)
            {
                return false;
            }
            if(userInput.Length > 1)
            {
                return false;
            }
            char startingChar = Char.ToUpper(userInput[0]);
            foreach (GasType value in Enum.GetValues(typeof(GasType)))
            {
                if(startingChar == (char) Convert.ToString(value)[0])
                {
                    result = true;
                }
            }
			return result;
		}

		// use this method to parse and check the double type entered
		// please use Double.TryParse() method 
		public static bool UserEnteredValidAmount(string userInput)
		{
			var result = false;

			// your implementation here
            if(String.IsNullOrEmpty(userInput) == true)
            {
                return false;
            }
            try
            {
                double amount;
                result = Double.TryParse(userInput, out amount);
                amount = Convert.ToDouble(userInput);
                if(amount >= 0.0)
                {
                    result = true;
                }else
                {
                    result = false;
                }
            }catch (Exception e)
            {
                result = false;
            }
			return result;
		}

		// use this method to map a valid char entry to its enum representation
		// e.g. User enters 'R' or 'r' --> this should be mapped to GasType.RegularGas
		// this mapping "must" be used within CalculateTotalCost() method later on
		public static GasType GasTypeMapper(char c)
		{
			GasType gasType = GasType.None;

            // your implementation here
            char findChar = Char.ToUpper(c);
            foreach (GasType value in Enum.GetValues(typeof(GasType)))
            {
                if(findChar == Convert.ToString(value)[0])
                {
                    gasType = (GasType) value;
                }
            }
			return gasType;
		}

		public static double GasPriceMapper(GasType gasType)
		{
			var result = 0.0;

            // your implementation here
            if((int)gasType == 1)
            {
                result = 1.94;
            }
            else if((int)gasType == 2)
            {
                result = 2.00;
            }
            else if((int)gasType == 3)
            {
                result = 2.24;
            }else if((int)gasType == 4)
            {
                result = 2.17;
            }
                return result;
	}

		public static void CalculateTotalCost(GasType gasType, int gasAmount, ref double totalCost)
		{
            // your implementation here
            totalCost = (double)GasPriceMapper(gasType) * gasAmount;
            Console.WriteLine("Your total cost for this purchase is : $" + totalCost);
		}
	}
}
