using System;
using System.Text;

namespace Milly
{
    public class InputValidator : IInputValidator
    {
        private readonly string[] input;
        public InputValidator(string[] _input)
        {
            input = _input;
        }

        public bool IsNumberOfTestCasesValid()
        {
            if (Int16.TryParse(input[0].Trim(), out Int16 numberOfTestCases))
            {
                if (1 <= numberOfTestCases && numberOfTestCases <= 10)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsTestCaseCountValid()
        {
            Int16 numberOfTestCases = Convert.ToInt16(input[0].Trim());
            if (input.Length == (numberOfTestCases * 2) + 1)
                return true;
            else
                return false;
        }
    }
}