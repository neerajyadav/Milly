using System;
using System.IO;

namespace Milly
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases = 0;
            try
            {
                using (StreamReader reader = File.OpenText("input.txt"))
                {
                    Console.WriteLine("Start reading input text file....");
                    //check if all chars are int.
                    string[] content = reader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    //validate input
                    //For production code we should use dependency injection to inject validator.
                    IInputValidator validator = new InputValidator(content);
                    if (!validator.IsNumberOfTestCasesValid())
                    {
                        Console.Error.WriteLine("Line 1: number of test cases not valid. Test cases count should be between 1 to 10.");
                        Console.WriteLine("Exiting application...");
                    }
                    if (!validator.IsTestCaseCountValid())
                    {
                        Console.Error.WriteLine("Invalid input. Number of test cases written does not match with count mentioned in Line 1.");
                        Console.WriteLine("Exiting application...");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not read the input file. Error:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
