using System;
using System.Globalization;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// ProjectEuler - Problem One
    /// </summary>
    public class MultiplesOfThreeAndFive : IProblem
    { 
        /// <summary>
        /// Provides a solution to the problem, you have a choice between which solution you would like to use
        /// </summary>
        /// <param name="solution"> Which solution you would like to use </param>
        /// <returns> A string representation of the solution </returns>
        /// <exception cref="ArgumentOutOfRangeException"> Appears when a solution type is entered that has not been accounted for </exception>
        public string Solution(Solution solution)
        {
            const int maximumValue = 1000;
            const int numberOne = 3;
            const int numberTwo = 5;
            
            return solution switch
            {
                Problems.Solution.First => First(maximumValue, numberOne, numberTwo),
                Problems.Solution.Revised => Revised(maximumValue, numberOne, numberTwo),
                _ => throw new ArgumentOutOfRangeException(nameof(solution), solution, null)
            };
        }

        /// <summary>
        /// First successful solution to the problem
        /// </summary>
        /// <param name="maximumValue"> The upper bound of divisible numbers </param>
        /// <param name="numberOne"> A divisor </param>
        /// <param name="numberTwo"> A divisor </param>
        /// <returns></returns>
        private static string First(int maximumValue, int numberOne, int numberTwo)
        {
            var sum = 0;
            
            for (var i = 0; i < maximumValue; i++)
            {
                if (i % numberOne == 0 || i % numberTwo == 0)
                {
                    sum += i;
                }
            }
            
            return sum.ToString();
        }
        
        /// <summary>
        /// Revised solution to the problem using idea's from other developers
        /// </summary>
        /// <param name="maximumValue"> The upper bound of divisible numbers </param>
        /// <param name="numberOne"> The first divisor </param>
        /// <param name="numberTwo"> The second divisor </param>
        /// <returns></returns>
        private static string Revised(int maximumValue, int numberOne, int numberTwo)
        {
            var numberOneSum = SumOfAllDivisibleNumbers(maximumValue, numberOne);
            var numberTwoSum = SumOfAllDivisibleNumbers(maximumValue, numberTwo);
            var leastCommonMultipleSum = SumOfAllDivisibleNumbers(maximumValue, LeastCommonMultiple(numberOne, numberTwo));

            return (numberOneSum + numberTwoSum - leastCommonMultipleSum).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Calculates the sum of all divisible numbers between 0 and the maximum value
        /// </summary>
        /// <param name="maximumValue"> The upper bound of divisible numbers </param>
        /// <param name="divisor"> The divisor </param>
        /// <returns></returns>
        private static double SumOfAllDivisibleNumbers(int maximumValue, int divisor)
        {
            var divisibleNumberCount = (maximumValue - 1) / divisor;
            
            return (double) divisor * divisibleNumberCount * (divisibleNumberCount + 1) / 2;
        }

        /// <summary>
        /// Calculates the greatest common divisor between two numbers
        /// </summary>
        /// <param name="numberOne"> The first number </param>
        /// <param name="numberTwo"> The second number </param>
        /// <returns></returns>
        private static int GreatestCommonDivisor(int numberOne, int numberTwo)
        {
            return numberTwo == 0 ? numberOne : GreatestCommonDivisor(numberTwo, numberOne % numberTwo);
        }

        /// <summary>
        /// Calculates the least common multiple between two numbers
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        private static int LeastCommonMultiple(int numberOne, int numberTwo)
        {
            return numberOne / GreatestCommonDivisor(numberOne, numberTwo) * numberTwo;
        }
    }
}