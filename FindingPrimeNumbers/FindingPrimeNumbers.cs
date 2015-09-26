namespace FindingPrimeNumbers
{
	public class FindingPrimeNumbers
	{
		public long FindSumOfPrimeNumbers(int n)
		{
			long sum = 0;

            // your solution goes in here
            int numberHasFound = 0;
            int numberCheck = 2;
            bool isPrimeNumber = true;
            while (numberHasFound < n)
            {
                for (int i = 2; i <= numberCheck - 1; i++)
                {
                    if (numberCheck % i == 0)
                    {
                        isPrimeNumber = false;
                    }
                    if (i >= numberCheck)
                    {
                        isPrimeNumber = true;
                    }
                }
                if (isPrimeNumber == true)
                {
                    numberHasFound++;
                    sum += numberCheck;
                }
                else
                {
                    isPrimeNumber = true;
                }
                numberCheck++;
            }
            return sum;
		}
	}
}
