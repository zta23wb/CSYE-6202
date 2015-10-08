using System;

namespace HealthRecordApp
{
	public class HealthProfileHelper
	{
		public static bool ValidateFirstName(string firstName)
		{
			return false;
		}

		public static bool ValidateLastName(string lastName)
		{
			return false;
		}

		public static bool ValidateGender(string enteredGender, ref Gender patientGender)
		{
			return false;
		}

		public static bool ValidateDateOfBirth(string enteredDOB, ref DateTime patientDOB)
		{
			return false;
		}

		public static bool ValidateHeight(string heightInString, ref int patientHeight)
		{
			return false;
		}

		public static bool ValidateWeight(string weightInString, ref int patientWeight)
		{
			return false;
		}
	}
}
