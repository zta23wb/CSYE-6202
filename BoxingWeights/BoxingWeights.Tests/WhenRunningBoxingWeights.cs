using NUnit.Framework;

namespace BoxingWeights.Tests
{
	[TestFixture]
	public class WhenRunningBoxingWeights
	{
		const string andString = " and ";
		BoxingWeightClassifier boxingWeightClassifier;

		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			boxingWeightClassifier = new BoxingWeightClassifier();
		}

		[Test]
		public void When_NumberIs0_ResultShouldBeStrawweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Strawweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(0);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs105_ResultShouldBeStrawweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Strawweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(105);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs106_ResultShouldBeJuniorFlyweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.JuniorFlyweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(106);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs112_ResultShouldBeFlyweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Flyweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(112);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs117_ResultShouldBeBantamWeightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Bantamweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(117);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs118_ResultShouldBantamweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Bantamweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(118);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs119_ResultShouldBeJuniorFeatherweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.JuniorFeatherweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(119);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs125_ResultShouldBeFeatherweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Featherweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(125);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs130_ResultShouldBeJuniorLightweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.JuniorLightweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(130);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs133_ResultShouldBeLightweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Lightweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(133);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs139_ResultShouldBeJuniorWelterweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.JuniorWelterweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(139);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs154_ResultShouldBeJuniorMiddleweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.JuniorMiddleweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(154);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs155_ResultShouldBeMiddleweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Middleweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(155);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs167_ResultShouldBeSuperMiddleweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.SuperMiddleweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(167);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs175_ResultShouldBeLightHeavyweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.LightHeavyweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(175);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs199_ResultShouldBeCruiserweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Cruiserweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(199);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs200_ResultShouldBeCruiserweightAndHeavyweight()
		{
			// prepare
			var expected = Constants.Cruiserweight + andString + Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(200);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_NumberIs260_ResultShouldBeHeavyweight()
		{
			// prepare
			var expected = Constants.Heavyweight;

			// action
			var actual = boxingWeightClassifier.ClassifyBoxingWeight(260);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}
	}
}
