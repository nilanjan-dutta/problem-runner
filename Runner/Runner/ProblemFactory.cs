using ProblemInterfaces;

namespace Runner
{
    /// <summary>
    /// Class implemented with "Factory Method" pattern to load the problems based on user choice
    /// </summary>
    internal static class ProblemFactory
    {
        /// <summary>
        /// Method to return a concrete implementation of <see cref="IProblem"/> based on incoming user input
        /// </summary>
        /// <param name="userChoice">The incoming user choice</param>
        /// <returns>A concrete type which implements <see cref="IProblem"/></returns>
        internal static IProblem LoadProblem(string userChoice)
        {
            return userChoice switch
            {
                "1" => new SumOfMultiple.SumOfMultiple(),
                "2" => new SequenceAnalysis.SequenceAnalysis(),
                _ => null,
            };
        }
    }
}
