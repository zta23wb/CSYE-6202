using NUnit.Framework;

namespace FizzBuzz.Tests
{
	[TestFixture]
	public class WhenRunningFizzBuzz
	{
		FizzBuzz fizzBuzz; 

		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			fizzBuzz = new FizzBuzz();
		}

		[Test]
		public void When_NumberIs0_ResultShouldBe0()
		{
			// prepare
			var expected = "0";

			// action
			var actual = fizzBuzz.RunFizzBuzz(0);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs1_ResultShouldBe1()
		{
			// prepare
			var expected = "1";

			// action
			var actual = fizzBuzz.RunFizzBuzz(1);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs3_ResultShouldBeFizz()
		{
			// prepare
			var expected = "Fizz";

			// action
			var actual = fizzBuzz.RunFizzBuzz(3);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs5_ResultShouldBeBuzz()
		{
			// prepare
			var expected = "Buzz";

			// action
			var actual = fizzBuzz.RunFizzBuzz(5);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}
		[Test]
		public void When_NumberIs9_ResultShouldBeFizz()
		{
			// prepare
			var expected = "Fizz";

			// action
			var actual = fizzBuzz.RunFizzBuzz(9);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs15_ResultShouldBeFizzBuzz()
		{
			// prepare
			var expected = "FizzBuzz";

			// action
			var actual = fizzBuzz.RunFizzBuzz(15);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs25_ResultShouldBeBuzz()
		{
			// prepare
			var expected = "Buzz";

			// action
			var actual = fizzBuzz.RunFizzBuzz(25);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs98_ResultShouldBe98()
		{
			// prepare
			var expected = "98";

			// action
			var actual = fizzBuzz.RunFizzBuzz(98);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}
	}
}
