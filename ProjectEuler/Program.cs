using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        private static void Main()
        {
            // Using stopwatch to measure solution performance
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            
            Console.WriteLine(new EvenFibonacciNumbers().Solution(Solution.First));
            
            stopwatch.Stop();
            Console.Write(stopwatch.ElapsedMilliseconds);
        }
    }
}