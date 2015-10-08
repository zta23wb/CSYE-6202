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

		#region Methods

		public int CalculateAge()
		{
			return UnknownValue;
		}

		public int CalculateMaxHeartRate()
		{
			return UnknownValue;
		}

		public decimal CalculateBMI()
		{
			return UnknownValue;
		}

		public void DisplayPatientProfile()
		{
		}

		#endregion
	}
}
