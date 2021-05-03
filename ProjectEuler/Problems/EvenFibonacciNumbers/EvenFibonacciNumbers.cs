using System;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// ProjectEuler - Problem Two
    /// </summary>
    public class EvenFibonacciNumbers : IProblem
    { 
        /// <summary>
        /// Provides a solution to the problem, you have a choice between which solution you would like to use
        /// </summary>
        /// <param name="solution"> Which solution you would like to use </param>
        /// <returns> A string representation of the solution </returns>
        /// <exception cref="ArgumentOutOfRangeException"> Appears when a solution type is entered that has not been accounted for </exception>
        public string Solution(Solution solution)
        {
            var maxValue = 4000000;
            
            return solution switch
            {
                Problems.Solution.First => First(maxValue),
                Problems.Solution.Revised => Revised(),
                _ => throw new ArgumentOutOfRangeException(nameof(solution), solution, null)
            };
        }

        /// <summary>
        /// First successful solution to the problem
        /// </summary>
        /// <returns></returns>
        private static string First(int maxValue)
        {
            var result = 0;
            
            var previousNumber = 0;
            var currentNumber = 1;
            
            while (currentNumber < maxValue)
            {
                var nextNumber = previousNumber + currentNumber;
                previousNumber = currentNumber;
                currentNumber = nextNumber;

                if (IsEven(currentNumber))
                {
                    result += currentNumber;
                }
            }

            return result.ToString();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsEven(int value)
        {
            return value % 2 == 0;
        }
        
        /// <summary>
        /// Revised solution to the problem using idea's from other developers
        /// </summary>
        private static string Revised()
        {
            return string.Empty;
        }
    }
}