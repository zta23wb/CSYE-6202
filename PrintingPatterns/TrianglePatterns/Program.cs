using System;

namespace TrianglePatterns
{
	class Program
	{
		static void Main(string[] args)
		{
            PrintPattern(10, 1, 1, "*", " ");
            Console.WriteLine();
            PrintPattern(10, 10, -1, "*", " ");
            Console.WriteLine();
            PrintPattern(10, 0, 1, " ", "*");
            Console.WriteLine();
            PrintPattern(10, 9, -1, " ", "*");
            Console.WriteLine();
            Console.ReadLine();
        }

        public static void PrintPattern(int lineNum, int startPatternOne, int goingDown, String patternOne, String patternTwo)
        {
            for (int line = 1; line <= lineNum; line++)
            {
                for (int i = 1; i <= startPatternOne; i++)
                {
                    Console.Write(patternOne);
                }
                for (int j = 0; j < lineNum - startPatternOne; j++)
                {
                    Console.Write(patternTwo);
                }
                startPatternOne += goingDown;
                Console.WriteLine();
            }
        }
    }
}
