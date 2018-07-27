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

                    string[] content = reader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    //For production code we should use dependency injection.
                    IInputValidator validator = new InputValidator(content);
                    ITestCaseRetriever retriever = new TestCaseRetriever(content, validator);

                    //validate input
                    if (!validator.IsTestCasesNumberValid())
                    {
                        Console.Error.WriteLine("Line 1: number of test cases not valid. Test cases count should be between 1 to 10.");
                        Console.WriteLine("Exiting application...");
                    }
                    if (!validator.IsCountOfWrittenTestCasesValid())
                    {
                        Console.Error.WriteLine("Invalid input. Number of test cases written does not match with count mentioned in Line 1.");
                        Console.WriteLine("Exiting application...");
                    }

                    numberOfTestCases = Convert.ToInt32(content[0].Trim());
                    for (int i = 1; i <= numberOfTestCases; i++)
                    {
                        try
                        {
                            var testCase = retriever.RetrieveTestCase(i);
                            var thinkingUnitsUsed = ThinkingUnitCalculator.NumberOfThinkingUnitsUsed(testCase.Item1, testCase.Item2);
                            Console.WriteLine(thinkingUnitsUsed);
                        }
                        catch (Exception e)
                        {
                            Console.Error.WriteLine(e.Message);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Can not read the input file. Error:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("****************************");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
