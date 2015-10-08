using System;
using NUnit.Framework;

namespace HealthRecordApp.Tests
{
	[TestFixture]
	public class WhenRunningHealthRecordApp
	{
		HealthProfile healthProfile;

		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			healthProfile = new HealthProfile()
			{
				FirstName = "Bart",
				LastName = "Simpson",
				Gender = Gender.Male,
				DOB = new DateTime(2005, 1, 1),
				WeightInPounds = 70,
				HeightInInches = 55
			};
		}

		#region Constructor Checks

		[Test]
		public void When_TestingDefaultConstructor_ResultShouldNotBeNull()
		{
			var actual = new HealthProfile();
			Assert.That(actual, Is.Not.Null);
		}

		[Test]
		public void When_TestingCustomConstructor_ResultShouldNotBeNull()
		{
			// prepare
			var actual = new HealthProfile()
			{
				FirstName = string.Empty,
				LastName = string.Empty,
				Gender = Gender.Unspecified,
				DOB = DateTime.MinValue,
				WeightInPounds = 0,
				HeightInInches = 0
			};

			// assert
			Assert.That(actual, Is.Not.Null);
		}

		#endregion

		#region Patient First Name Validation Checks

		[Test]
		public void When_TestingValidateFirstName_IfFirstNameIsEmpty_ResultShouldBeFalse()
		{
			// prepare
			var firstName = string.Empty;

			// act
			var actual = HealthProfileHelper.ValidateFirstName(firstName);

			// assert
			Assert.That(actual, Is.False);
		}

		[Test]
		public void When_TestingValidateFirstName_IfFirstNameIsNull_ResultShouldBeFalse()
		{
			// prepare
			string firstName = null;

			// act
			var actual = HealthProfileHelper.ValidateFirstName(firstName);

			// assert
			Assert.That(actual, Is.False);
		}

		[Test]
		public void When_TestingValidateFirstName_IfFirstNameIsAllWhiteSpaces_ResultShouldBeFalse()
		{
			// prepare
			string firstName = new String(' ', 8);

			// act
			var actual = HealthProfileHelper.ValidateFirstName(firstName);

			// assert
			Assert.That(actual, Is.False);
		}

		[Test]
		public void When_TestingValidateFirstName_IfFirstNameIsValid_ResultShouldBeTrue()
		{
			// prepare
			var firstName = "Bart";

			// act
			var actual = HealthProfileHelper.ValidateFirstName(firstName);

			// assert
			Assert.That(actual, Is.True);
		}

		#endregion

		#region Patient Last Name Validation Checks

		[Test]
		public void When_TestingValidateLastName_IfLastNameIsEmpty_ResultShouldBeFalse()
		{
			// prepare
			var lastName = string.Empty;

			// act
			var actual = HealthProfileHelper.ValidateLastName(lastName);

			// assert
			Assert.That(actual, Is.False);
		}

		[Test]
		public void When_TestingValidateLastName_IfLastNameIsNull_ResultShouldBeFalse()
		{
			// prepare
			string lastName = null;

			// act
			var actual = HealthProfileHelper.ValidateLastName(lastName);

			// assert
			Assert.That(actual, Is.False);
		}

		[Test]
		public void When_TestingValidateLastName_IfLastNameIsAllWhiteSpaces_ResultShouldBeFalse()
		{
			// prepare
			string lastName = new String(' ', 5);

			// act
			var actual = HealthProfileHelper.ValidateLastName(lastName);

			// assert
			Assert.That(actual, Is.False);
		}

		[Test]
		public void When_TestingValidateLastName_IfLastNameIsValid_ResultShouldBeTrue()
		{
			// prepare
			var lastName = "Simpson";

			// act
			var actual = HealthProfileHelper.ValidateLastName(lastName);

			// assert
			Assert.That(actual, Is.True);
		}

		#endregion

		#region Patient Gender Validation Checks

		[Test]
		public void When_TestingValidateGender_IfGenderIsNotAValidEnum_ResultShouldBeFalse()
		{
			// prepare
			string enteredGender = "Unknown";
			Gender patientGender = Gender.Unspecified;

			// act
			var actual = HealthProfileHelper.ValidateGender(enteredGender, ref patientGender);

			// assert
			Assert.That(actual, Is.False);

			// prepare
			enteredGender = string.Empty;

			// act
			actual = HealthProfileHelper.ValidateGender(enteredGender, ref patientGender);

			// assert
			Assert.That(actual, Is.False);
			Assert.That(patientGender, Is.EqualTo(Gender.Unspecified));
		}

		[Test]
		public void When_TestingValidateGender_IfGenderIsValid_ResultShouldBeTrue()
		{
			// prepare
			string enteredGender = "Unspecified";
			Gender patientGender = Gender.Unspecified;

			// act
			var actual = HealthProfileHelper.ValidateGender(enteredGender, ref patientGender);

			// assert
			Assert.That(actual, Is.True);
			Assert.That(patientGender, Is.EqualTo(Gender.Unspecified));

			// prepare
			enteredGender = "Male";

			// act
			actual = HealthProfileHelper.ValidateGender(enteredGender, ref patientGender);

			// assert
			Assert.That(actual, Is.True);
			Assert.That(patientGender, Is.EqualTo(Gender.Male));

			// prepare
			enteredGender = "Female";

			// act
			actual = HealthProfileHelper.ValidateGender(enteredGender, ref patientGender);

			// assert
			Assert.That(actual, Is.True);
			Assert.That(patientGender, Is.EqualTo(Gender.Female));
		}

		#endregion

		#region Patient DOB Validation Checks

		[Test]
		public void When_TestingValidateDateOfBirth_IfDOBIsNotAValidDateTime_ResultShouldBeFalse()
		{
			// prepare
			string enteredDOB = "October 32 2015";
			DateTime patientDOB = DateTime.MinValue;

			// act
			var actual = HealthProfileHelper.ValidateDateOfBirth(enteredDOB, ref patientDOB);

			// assert
			Assert.That(actual, Is.False);
			Assert.That(patientDOB, Is.EqualTo(DateTime.MinValue));
		}

		[Test]
		public void When_TestingValidateDateOfBirth_IfDOBIsGreaterThanCurrentDateTime_ResultShouldBeFalse()
		{
			// prepare
			string enteredDOB = "November/11/2015";
			DateTime patientDOB = DateTime.MinValue;

			// act
			var actual = HealthProfileHelper.ValidateDateOfBirth(enteredDOB, ref patientDOB);

			// assert
			Assert.That(actual, Is.False);
			Assert.That(patientDOB, Is.EqualTo(DateTime.MinValue));
		}

		[Test]
		public void When_TestingValidateFirstName_IfDOBIsAValidDateTime_ResultShouldBeTrue()
		{
			// prepare
			string enteredDOB = "Oct/1/2015";
			DateTime patientDOB = DateTime.MinValue;

			// act
			var actual = HealthProfileHelper.ValidateDateOfBirth(enteredDOB, ref patientDOB);

			// assert
			Assert.That(actual, Is.True);
			Assert.That(patientDOB, Is.EqualTo(new DateTime(2015, 10, 1)));
		}

		#endregion

		#region Patient Height Validation Checks

		[Test]
		public void When_TestingValidateHeight_IfHeightIsNotAValidInteger_ResultShouldBeFalse()
		{
			// prepare
			string heightInString = "Garbage string";
			int patientHeight = 0;

			// act
			var actual = HealthProfileHelper.ValidateHeight(heightInString, ref patientHeight);

			// assert
			Assert.That(actual, Is.False);
			Assert.That(patientHeight, Is.EqualTo(0));
		}

		[Test]
		public void When_TestingValidateHeight_IfHeightIsSmallerOrEqualToZero_ResultShouldBeFalse()
		{
			// prepare
			string heightInString = "0";
			int patientHeight = 0;

			// act
			var actual = HealthProfileHelper.ValidateHeight(heightInString, ref patientHeight);

			// assert
			Assert.That(actual, Is.False);
			Assert.That(patientHeight, Is.EqualTo(0));
		}

		[Test]
		public void When_TestingValidateHeight_IfHeightIsValid_ResultShouldBeTrue()
		{
			// prepare
			string heightInString = "55";
			int patientHeight = 0;

			// act
			var actual = HealthProfileHelper.ValidateHeight(heightInString, ref patientHeight);

			// assert
			Assert.That(actual, Is.True);
			Assert.That(patientHeight, Is.EqualTo(55));
		}

		#endregion

		#region Patient Weight Validation Checks

		[Test]
		public void When_TestingValidateWeight_IfWeightIsNotAValidInteger_ResultShouldBeFalse()
		{
			// prepare
			string weightInString = "Garbage string";
			int patientWeight = 0;

			// act
			var actual = HealthProfileHelper.ValidateWeight(weightInString, ref patientWeight);

			// assert
			Assert.That(actual, Is.False);
			Assert.That(patientWeight, Is.EqualTo(0));
		}

		[Test]
		public void When_TestingValidateWeight_IfWeightIsSmallerOrEqualToZero_ResultShouldBeFalse()
		{
			// prepare
			string weightInString = "0";
			int patientWeight = 0;

			// act
			var actual = HealthProfileHelper.ValidateWeight(weightInString, ref patientWeight);

			// assert
			Assert.That(actual, Is.False);
			Assert.That(patientWeight, Is.EqualTo(0));
		}

		[Test]
		public void When_TestingValidateWeight_IfWeightIsValid_ResultShouldBeTrue()
		{
			// prepare
			string weightInString = "70";
			int patientWeight = 0;

			// act
			var actual = HealthProfileHelper.ValidateWeight(weightInString, ref patientWeight);

			// assert
			Assert.That(actual, Is.True);
			Assert.That(patientWeight, Is.EqualTo(70));
		}

		#endregion

		[Test]
		public void When_TestingCalculateAge_GivenCurrentYearAndPatientBirthYear_ReturnsCorrectAge()
		{
			// act
			var calculatedAge = healthProfile.CalculateAge();

			// assert
			Assert.That(calculatedAge, Is.EqualTo(10));
		}

		[Test]
		public void When_TestingCalculateMaxHeartRate_GivenAge_ReturnsCorrectMaxHeartRate()
		{
			// act
			var calculatedMaxHeartRate = healthProfile.CalculateMaxHeartRate();

			// assert
			Assert.That(calculatedMaxHeartRate, Is.EqualTo(210));
		}

		[Test]
		public void When_TestingCalculateBMI_GivenWeightAndHeight_ReturnsCorrectBMI()
		{
			// act
			var calculatedBMI = healthProfile.CalculateBMI();

			// assert
			Assert.That(calculatedBMI, Is.EqualTo(16.27m));
		}
	}
}
