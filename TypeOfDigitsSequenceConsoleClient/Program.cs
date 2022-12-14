namespace TypeOfDigitsSequenceConsoleClient
{
    using System;
    
    using static TypeOfDigitsSequenceLogic.IntegersExtension;

    internal static class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter number for check, please:");
                var number = ParseStringToNum(Console.ReadLine());
                Console.WriteLine(GetTypeOfDigitsSequence(number));
                Console.WriteLine("Press Enter for a next iteration.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static long ParseStringToNum(string? stringNumber)
        {
            long digitNumber = 0;
            try
            {
                if (stringNumber != null) digitNumber = long.Parse(stringNumber);
                return digitNumber;
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not an digits number. Use only digit numbers, please.", stringNumber);
            }

            return 0;
        }
    }
}
