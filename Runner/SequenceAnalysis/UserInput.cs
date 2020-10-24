using ProblemInterfaces;
using System;

namespace SequenceAnalysis
{
    class UserInput : IUserInput
    {
        /// <summary>
        /// Method to return the Input from user
        /// Implements <see cref="IUserInput.GetUserInput"/>
        /// </summary>
        /// <returns>The user input</returns>
        public string GetUserInput()
        {
            return Console.ReadLine().Trim();
        }
    }
}
