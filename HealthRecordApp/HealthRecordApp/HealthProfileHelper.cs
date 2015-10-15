using System;
using System.Globalization;

namespace HealthRecordApp
{
	public class HealthProfileHelper
	{
		public static bool ValidateFirstName(string firstName)
		{
            if(String.IsNullOrWhiteSpace(firstName) || String.IsNullOrEmpty(firstName))
            {
                return false;
            }
            return true;
		}

		public static bool ValidateLastName(string lastName)
		{
            if (String.IsNullOrWhiteSpace(lastName) || String.IsNullOrEmpty(lastName))
            {
                return false;
            }
            return true;
        }

		public static bool ValidateGender(string enteredGender, ref Gender patientGender)
		{
            if(enteredGender.Equals("Unspecified")) {
                patientGender = Gender.Unspecified;
                return true;
            }else if(enteredGender.Equals("Male"))
            {
                patientGender = Gender.Male;
                return true;
            }else if(enteredGender.Equals("Female"))
            {
                patientGender = Gender.Female;
                return true;
            }
			return false;
		}

		public static bool ValidateDateOfBirth(string enteredDOB, ref DateTime patientDOB)
		{
            bool result = false;
            try {
                if(DateTime.TryParse(enteredDOB,out patientDOB))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                if(DateTime.Now.CompareTo(patientDOB) < 0)
                {
                    patientDOB = DateTime.MinValue;
                    return false;
                }

            }catch (Exception e)
            {
                return false;
            }
            return result;
		}

		public static bool ValidateHeight(string heightInString, ref int patientHeight)
		{
            try
            {
                int heightNum = Int32.Parse(heightInString);
                if(heightNum <= 0)
                {
                    return false;
                }
                patientHeight = heightNum;
                return true;
            }catch(FormatException e)
            {
                return false;
            }catch(IndexOutOfRangeException e)
            {
                return false;
            }
		}

		public static bool ValidateWeight(string weightInString, ref int patientWeight)
		{
            try
            {
                int weightNum = Int32.Parse(weightInString);
                if(weightNum <= 0)
                {
                    return false;
                }
                patientWeight = weightNum;
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
            catch (IndexOutOfRangeException e)
            {
                return false;
            }
        }
	}
}
