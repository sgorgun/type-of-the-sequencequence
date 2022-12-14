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
                (false, true, false, > 1) => "Strictly Increasing.",
                (true, true, false, > 1) => "Increasing.",
                (false, false, true, > 1) => "Strictly Decreasing.",
                (true, false, true, > 1) => "Decreasing.",
                (true, false, false, > 1) => "Monotonous.",
                (false, false, false, 1) => "One digit number.",
                _ => "Unordered.",
            };

        private static (bool equals, bool increase, bool decrease, long lengtsOfNuber) AnalizeNumber(long number)
        {
            long lengtsOfNuber = 1;
            bool equals = false;
            bool increase = false;
            bool decrease = false;
            (bool equals, bool more, bool less, long count) resultOfOperations = ((equals, increase, decrease, lengtsOfNuber));

            for (; number != 0; number /= 10)
            {
                long termA = number % 10;
                long termB = (number % 100 - termA) / 10;
                lengtsOfNuber++;

                if (termB == 0)
                {
                    return resultOfOperations;
                }
                if (termA == termB)
                {
                    equals = true;
                }
                if (termA > termB)
                {
                    increase = true;
                }
                if (termA < termB)
                {
                    decrease = true;
                }
                resultOfOperations = (equals, increase, decrease, lengtsOfNuber);
            }

            return resultOfOperations;
        }

    }
}