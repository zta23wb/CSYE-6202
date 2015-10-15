using System;

namespace HealthRecordApp
{
    class Program
    {
        public static readonly int green = 1;
        public static readonly int red = -1;
        static void Main(string[] args)
        {

            HealthProfile patient = new HealthProfile();
            patient.Gender = Gender.Unspecified;
            patient.WeightInPounds = 0;
            patient.HeightInInches = 0;
            patient.DOB = DateTime.Now;
            String input = null;
            input = askFirstTime("first name");
            while (HealthProfileHelper.ValidateFirstName(input) == false)
            {
                input = askAgain("first name");
                continue;
            }
            patient.FirstName = input;

            input = askFirstTime("last name");
            while (HealthProfileHelper.ValidateFirstName(input) == false)
            {
                input = askAgain("last name");
                continue;
            }
            patient.LastName = input;

            Gender passInGender = Gender.Unspecified;
            input = askFirstTime("gender (Unspecified/Male/Female)");
            while (HealthProfileHelper.ValidateGender(input, ref passInGender) == false)
            {
                input = askGenderAgain("gender (Unspecified/Male/Female)");
                continue;
            }
            patient.Gender = passInGender;

            DateTime passInDate = DateTime.Now;
            input = askFirstTime("date of birth");
            while (HealthProfileHelper.ValidateDateOfBirth(input, ref passInDate) == false)
            {
                input = askAgain("date of birth");
                continue;
            }
            patient.DOB = passInDate;

            int passInHeight = 0;
            input = askFirstTime("height");
            while (HealthProfileHelper.ValidateHeight(input, ref passInHeight) == false)
            {
                input = askAgain("height");
                continue;
            }
            patient.HeightInInches = passInHeight;

            int passInWeight = 0;
            input = askFirstTime("weight");
            while (HealthProfileHelper.ValidateHeight(input, ref passInWeight) == false)
            {
                input = askAgain("weight");
                continue;
            }
            patient.WeightInPounds = passInWeight;
            Console.WriteLine();
            Console.WriteLine();
            patient.DisplayPatientProfile();
        }


        public static void askQuestion(string parameter, int flag)
        {
            if (flag == 1)
            {
                Console.Write("Please enter patient's " + parameter + ": ");
            }
            else
            {
                Console.Write("Invalid " + parameter + ". ");
            }
        }

        public static string askAgain(String parameter)
        {
            askQuestion(parameter, red);
            askQuestion(parameter, green);
            return Console.ReadLine();
        }

        public static string askGenderAgain(String parameter)
        {
            askQuestion("gender", red);
            askQuestion(parameter, green);
            return Console.ReadLine();
        }
        public static string askFirstTime(String parameter)
        {
            askQuestion(parameter, green);
            return Console.ReadLine();
        }

    }
}
