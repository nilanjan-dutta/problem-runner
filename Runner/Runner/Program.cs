using System;
using System.Collections.Generic;

namespace Runner
{
    class Program
    {
        static List<string> MATCHING_OPTIONS = new List<string> { "1", "2" };

        static void Main(string[] args)
        {
            bool doSolve = true;            
            while (doSolve)
            {
                SolveProblem();
                Console.WriteLine("\n");
                Console.WriteLine("To Solve again, press 'y'. Press any other key to exit:");
                var choice = Console.ReadLine();
                doSolve = choice == "y" || choice == "Y";
            }

            //local functions
            static void SolveProblem()
            {
                Console.WriteLine("Hello ! Which problem do you want to solve today?");
                Console.WriteLine("\n");
                Console.WriteLine("Press 1 for 'Sum of Multiple'");
                Console.WriteLine("Press 2 for 'Sequence Analysis'");
                Console.WriteLine("\n");

                string userInput = Console.ReadLine();
                while (IsInvalidInput(userInput))
                {
                    Console.WriteLine("Please select a valid option: 1 or 2");
                    userInput = Console.ReadLine();
                }

                ExecuteProblem(userInput);

                static bool IsInvalidInput(string userInput)
                {
                    return string.IsNullOrWhiteSpace(userInput) || !MATCHING_OPTIONS.Contains(userInput);
                }

                static void ExecuteProblem(string userInput)
                {
                    var problem = ProblemFactory.LoadProblem(userInput);

                    problem?.Solve();
                }
            }
        }         
    }
}
