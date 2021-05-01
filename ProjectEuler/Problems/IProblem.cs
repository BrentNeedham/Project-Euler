using System;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Interface to ensure all problems have a Solution method
    /// </summary>
    public interface IProblem
    {
        public string Solution(Solution solution);
    }
}