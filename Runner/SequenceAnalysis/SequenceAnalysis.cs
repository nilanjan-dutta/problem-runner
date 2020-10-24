using ProblemInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceAnalysis
{
    /// <summary>
    /// Solves the "Sequence Analysis" problem
    /// </summary>
    public class SequenceAnalysis : IProblem
    {
        public const string AskForValidInput = "Please enter a valid string: ";
        public const string AskForUserInput = "Please provide the string to check: ";
        public const string NoUpperCaseLettersFound = "No Upper case word(s) found in the given string";

        /// <summary>
        /// Method that starts the <see cref="SequenceAnalysis"/> problem solution
        /// Implements the interface definition from <see cref="IProblem.Solve"/>
        /// </summary>
        public void Solve()
        {
            var userInput = new UserInput();
            var inputString = TakeUserInput(userInput);
            var upperCaseCharacters = FindUpperCaseWords(inputString);
            ShowResult(upperCaseCharacters);
        }

        /// <summary>
        /// Takes user inputs from the defined type of <see cref="IUserInput"/>
        /// Implementation of <see cref="IProblem.TakeUserInput(IUserInput)"/>
        /// </summary>
        /// <param name="userInput">Concrete implementation of <see cref="IUserInput"/></param>
        /// <returns>The input</returns>
        public string TakeUserInput(IUserInput userInput)
        {
            Console.WriteLine(AskForUserInput);
            var inputString = userInput.GetUserInput();

            // check for valid input: non empty or null string
            while (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine(AskForValidInput);
                inputString = userInput.GetUserInput();
            }
            return inputString;
        }

        /// <summary>
        /// Finds all the upper case words in the given string
        /// </summary>
        /// <param name="userInput">The input string in which upper case words to be found</param>
        /// <returns>List of characters created from the uppercase words in the given input</returns>
        public List<char> FindUpperCaseWords(string userInput)
        {
            var words = userInput.Split(" ");
            var upperCaseChars = words.Where(word => word.All(ch => char.IsUpper(ch)))
                                      .SelectMany(word => word.ToCharArray());

            return upperCaseChars.ToList();
        }

        /// <summary>
        /// Sorts the given character list alphabetically
        /// </summary>
        /// <param name="upperCaseCharacters">The list of characters to be sorted</param>
        /// <returns>String representation of alphabetically sorted characters</returns>
        public string SortCharacters(List<char> upperCaseCharacters)
        {
            var sortedList = upperCaseCharacters.OrderBy(ch => ch).ToList();
            return string.Join("", sortedList);
        }

        /// <summary>
        /// Shows the result
        /// </summary>
        /// <param name="upperCaseCharacters">The uppercase character list</param>
        public void ShowResult(List<char> upperCaseCharacters)
        {
            if (upperCaseCharacters.Any())
            {
                string finalReult = SortCharacters(upperCaseCharacters);
                Console.WriteLine($"Output: {finalReult}");
            }
            else
            {
                Console.WriteLine(NoUpperCaseLettersFound);
            }
        }
    }
}
