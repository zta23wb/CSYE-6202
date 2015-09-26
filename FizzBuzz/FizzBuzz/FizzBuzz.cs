namespace FizzBuzz
{
	public class FizzBuzz
	{
		public string RunFizzBuzz(int number)
		{
			string result = number.ToString();

            // your solution/implementation should go in here
            if (number == 0)
            {
                return result;
            }
            switch (number % 15)
            {
                case 0:
                    result = "FizzBuzz";
                    break;
                case 3:
                case 6:
                case 9:
                case 12:
                    result = "Fizz";
                    break;
                case 5:
                case 10:
                    result = "Buzz";
                    break;
                default:
                    break;
            }

            return result;
		}
	}
}
