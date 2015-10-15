using System;

namespace HealthRecordApp
{
	public enum Gender
	{
		Unspecified,
		Male,
		Female
	}

	public class HealthProfile
	{
		private const int UnknownValue = -1;
        private string firstName;
        private string lastName;
        private Gender genderType;
        private DateTime birthDate;
        private int weight;
        private int height;

        #region Methods

        public int CalculateAge()
		{
            int yearATM = DateTime.Now.Year;
            int yearGiven = birthDate.Year;
			return yearATM - yearGiven;
		}

		public int CalculateMaxHeartRate()
		{
			return (int) 220 - CalculateAge();
		}

		public decimal CalculateBMI()
		{
            decimal doubleBMI =(decimal) ((weight * 703) * 100.000 / (height * height));
            //decimal BMI = Math.Floor(doubleBMI) / 100;
            decimal BMI = Math.Round(doubleBMI/100, 2);
            return BMI;
		}

		public void DisplayPatientProfile()
		{
            Console.WriteLine("Displaying Patient Profile:");
            Console.WriteLine("===========================");
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("Gender: " + genderType);
            Console.WriteLine("Date of birth: " + birthDate.ToString("MM/dd/yyyy"));
            Console.WriteLine("Height: " + height + " inches");
            Console.WriteLine("Weight: " + weight + " pounds");
            Console.WriteLine("Age: " + CalculateAge());
            Console.WriteLine("Max Heart Rate: " + CalculateMaxHeartRate());
            Console.WriteLine("BMI: " + CalculateBMI());
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public Gender Gender
        {
            get { return genderType;  }
            set { genderType = value; }
        }

        public DateTime DOB
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public int WeightInPounds
        {
            get { return weight; }
            set { weight = value; }
        }

        public int HeightInInches
        {
            get { return height; }
            set { height = value; }
        }


        public override string ToString()
        {
            return firstName + " " + lastName;
        }
        #endregion
    }
}
