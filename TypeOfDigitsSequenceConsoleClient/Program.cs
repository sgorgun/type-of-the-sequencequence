namespace TypeOfDigitsSequenceConsoleClient
{
    using System;
    using static System.Console;
    using static TypeOfDigitsSequenceLogic.IntegersExtension;

    static class Program
    {
        public static void Main()
        {
            while (true)
            {
                WriteLine("Enter number for check, please:");
                long number = long.Parse(ReadLine() ?? string.Empty);
                WriteLine(GetTypeOfDigitsSequence(number));
                WriteLine("Press Enter for a next iteration.");
                ReadLine();
                Clear();
            }
        }
    }
}
