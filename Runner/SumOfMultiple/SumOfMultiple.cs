using ProblemInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfMultiple
{
    /// <summary>
    /// Solves the "SumOfMultiple" problem
    /// </summary>
    public class SumOfMultiple : IProblem
    {
        public const string AskForValidInput = "Please enter a valid integer: ";
        public const string AskForUserInput = "Please provide the limit to check: ";
        public const string TooLargeLimit = "The limit provided is too large to calculate the sum. Result is partial.";

        readonly List<int> MULTIPLES_OF = new List<int> { 3, 5 };

        /// <summary>
        /// Method that starts the <see cref="SumOfMultiple"/> problem solution
        /// Implements the interface definition from <see cref="IProblem.Solve"/>
        /// </summary>
        public void Solve()
        {
            IUserInput userInput = new UserInput();
            var limit = int.Parse(TakeUserInput(userInput));
            try
            {
                var sum = PerformSum(limit);
                Console.WriteLine(GetFinalString(sum));
            }
            catch (ArgumentException)
            {
                Solve();
            }
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
            var input = userInput.GetUserInput();

            //check for valid input: not emty or null and valid integer
            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
            {
                Console.WriteLine(AskForValidInput);
                input = userInput.GetUserInput();
            }

            return input;
        }

        /// <summary>
        /// Performs addition based on a limit for the multiple of predefined numbers. 
        /// Here that is of 3 and 5
        /// Throws <see cref="ArgumentException"/> is the sum exceeds maximum integer limit
        /// </summary>
        /// <param name="limit">The limit provided by the user</param>
        /// <returns>The summed up result</returns>
        public int PerformSum(int limit)
        {
            var sum = 0;

            int absoluteLimit = Math.Abs(limit);

            for (int num = 0; num < absoluteLimit; num++)
            {
                if (MULTIPLES_OF.Any(n => num % n == 0))
                {
                    sum += num;
                    // check if the limit is too high while calculating
                    if (sum < 0)
                    {
                        Console.WriteLine(TooLargeLimit);
                        throw new ArgumentException(TooLargeLimit);
                    }
                }
            }

            // if the provided number was negative integer, convert the sum into a negative number
            if (limit < 0)
            {
                sum = sum * -1;
            }

            return sum;
        }
        
        /// <summary>
        /// Gets the final output string with the summed up result
        /// It converts the list of numbers of which the multiples are found in a string representation joined by comma
        /// </summary>
        /// <param name="sum">The calculated result</param>
        /// <returns>String to be printed in the console</returns>
        public string GetFinalString(int sum)
        {
            return $"The sum of the multiples of {GetNumberListInCommaSeparatedString(MULTIPLES_OF)} is : {sum}";

            // local function to join the list of "multiple of" numbers joind in a string
            string GetNumberListInCommaSeparatedString(List<int> numbersList)
            {
                return string.Join(",", numbersList.Select(n => n.ToString()).ToArray());
            }
        }
    }
}
