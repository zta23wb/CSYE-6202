using NUnit.Framework;

namespace FindingPrimeNumbers.Tests
{
	[TestFixture]
	public class WhenFindingPrimeNumbers
	{
		[Test]
		public void When_NIs0_SumShouldBe0()
		{
			// prepare
			var findingPrimeNumbers = new FindingPrimeNumbers();
			var expected = 0;

			// act
			var actual = findingPrimeNumbers.FindSumOfPrimeNumbers(0);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NIs1_SumShouldBe2()
		{
			// prepare
			var findingPrimeNumbers = new FindingPrimeNumbers();
			var expected = 2;

			// act
			var actual = findingPrimeNumbers.FindSumOfPrimeNumbers(1);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NIs2_SumShouldBe5()
		{
			// prepare
			var findingPrimeNumbers = new FindingPrimeNumbers();
			var expected = 5;

			// act
			var actual = findingPrimeNumbers.FindSumOfPrimeNumbers(2);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NIs10_SumShouldBe129()
		{
			// prepare
			var findingPrimeNumbers = new FindingPrimeNumbers();
			var expected = 129;

			// act
			var actual = findingPrimeNumbers.FindSumOfPrimeNumbers(10);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NIs25_SumShouldBe1060()
		{
			// prepare
			var findingPrimeNumbers = new FindingPrimeNumbers();
			var expected = 1060;

			// act
			var actual = findingPrimeNumbers.FindSumOfPrimeNumbers(25);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}
	}
}
