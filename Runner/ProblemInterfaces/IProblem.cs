namespace ProblemInterfaces
{
    /// <summary>
    /// Interface to be implemented by the problems that can be hooked into.
    /// </summary>
    public interface IProblem
    {
        /// <summary>
        /// Solve the loaded problem
        /// </summary>
        void Solve();

        /// <summary>
        /// Method to take user input through ways provided by the concrete implementation of <see cref="IUserInput"/>
        /// </summary>
        /// <param name="userInput">Dependency injection for <see cref="IUserInput"/></param>
        /// <returns></returns>
        string TakeUserInput(IUserInput userInput);
    }
}
