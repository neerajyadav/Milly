using System;
using System.Text;
using System.Linq;

namespace Milly
{
    public class InputValidator : IInputValidator
    {
        private readonly string[] input;
        public InputValidator(string[] _input)
        {
            input = _input;
        }

        public bool IsTestCasesNumberValid()
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

        public bool IsCountOfWrittenTestCasesValid()
        {
            Int16 numberOfTestCases = Convert.ToInt16(input[0].Trim());
            if (input.Length == (numberOfTestCases * 2) + 1)
                return true;
            else
                return false;
        }

        public bool IsNumOfStudentsRowHasValidData(int index)
        {
            string row = input[index];
            if (int.TryParse(row, out int numOfStudents))
            {
                if (1 <= numOfStudents && numOfStudents <= 100000)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsStudentRankRowHasValidData(int index, int numOfStudents)
        {
            string row = input[index];
            if (row.Replace(" ", "").All(char.IsDigit))
            {
                if (row.Split(' ').Length == numOfStudents)
                    return true;
            }
            return false;
        }

        public bool ValidateTestCase(int studentCount, int[] ranks)
        {
            if (studentCount != ranks.Length)
                return false;

            if (ranks.Distinct().Count() != ranks.Length)
                return false;

            return true;
        }
    }
}