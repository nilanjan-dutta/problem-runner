namespace ProblemInterfaces
{
    /// <summary>
    /// Interface to be implemented by the user inpur providers.
    /// </summary>
    public interface IUserInput
    {
        /// <summary>
        /// Method to collect user input
        /// </summary>
        /// <returns>The collected user input</returns>
        string GetUserInput();
    }
}
