using System.ComponentModel;
using System.Text;

namespace TypeOfDigitsSequenceLogic
{
    public static class IntegersExtension
    {
        /// <summary>
        /// Implement a GetTypeOfDigitsSequence extension method that obtains
        /// in the form of a string information about the type of sequence
        /// that the digits of a given integer number represents.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>
        /// For example:
        /// 23456789L -> "Strictly Increasing."
        /// long.MinValue ->  "Unordered."
        /// long.MaxValue -> "Unordered."
        /// 9876543210L -> "Strictly Decreasing."
        /// 111111111111111L -> "Monotonous."
        /// 8765432110L -> "Decreasing."
        /// 11234567889L -> "Increasing."
        /// 1L ->  "One digit number."
        /// -1L -> "One digit number."
        /// </returns>
        //public static bool GetTypeOfDigitsSequence(long number, out bool equals, out bool more, out bool less)
        public static string GetTypeOfDigitsSequence(this long number) =>
            AnalizeNumber(number) switch
            {
                (false, true, false) => "Strictly Increasing.",
                (true, true, false) => "Increasing.",
                (false, false, true) => "Strictly Decreasing.",
                (true, false, true) => "Decreasing.",
                (true, false, false) => "Monotonous.",
                (false, false, false) => "One digit number.",
                _ => "Unordered.",
            };

        private static (bool, bool, bool) AnalizeNumber(long number)
        {
            (bool equals, bool more, bool less) resultOfOperations = (false, false, false);

            for (; number != 0; number /= 10)
            {
                long termA = number % 10;
                long termB = (number % 100 - termA) / 10;

                if (termB == 0)
                {
                    return resultOfOperations;
                }
                if (termA == termB)
                {
                    resultOfOperations.equals = true;
                }
                if (termA > termB)
                {
                    resultOfOperations.more = true;
                }
                if (termA < termB)
                {
                    resultOfOperations.less = true;
                }
            }

            return number is <= 9 and >= -9 ? (false, false, false) : resultOfOperations;
        }

    }
}