namespace BoxingWeights
{
	public class BoxingWeightClassifier
	{
		public string ClassifyBoxingWeight(int weightInPounds)
		{
			string result = weightInPounds.ToString();

            // your solution/implementation should go in here
            //result = "Heavyweight and ";
            result = "";
            if (weightInPounds <= 105)
            {
                result += "Strawweight";
            }
            else if (weightInPounds <= 108)
            {
                result += "JuniorFlyweight";
            }
            else if (weightInPounds <= 112)
            {
                result += "Flyweight";
            }
            else if (weightInPounds <= 115)
            {
                result += "JuniorBantamweight";
            }
            else if (weightInPounds <= 118)
            {
                result += "Bantamweight";
            }
            else if (weightInPounds <= 122)
            {
                result += "JuniorFeatherweight";
            }
            else if (weightInPounds <= 126)
            {
                result += "Featherweight";
            }
            else if (weightInPounds <= 130)
            {
                result += "JuniorLightweight";
            }
            else if (weightInPounds <= 135)
            {
                result += "Lightweight";
            }
            else if (weightInPounds <= 140)
            {
                result += "JuniorWelterweight";
            }
            else if (weightInPounds <= 147)
            {
                result += "Welterweight";
            }
            else if (weightInPounds <= 154)
            {
                result += "JuniorMiddleweight";
            }
            else if (weightInPounds <= 160)
            {
                result += "Middleweight";
            }
            else if (weightInPounds <= 168)
            {
                result += "SuperMiddleweight";
            }
            else if (weightInPounds <= 175)
            {
                result += "LightHeavyweight";
            }
            else if (weightInPounds <= 200)
            {
                result += "Cruiserweight";
            }else
            {
                return "Heavyweight";
            }
            return result + " and Heavyweight";
		}
	}
}
