using System;
using System.Linq;

namespace Milly
{
    public class TestCaseRetriever : ITestCaseRetriever
    {
        private readonly string[] input;
        private readonly IInputValidator validator;
        public TestCaseRetriever(string[] _input, IInputValidator _validator)
        {
            input = _input;
            validator = _validator;
        }

        public Tuple<int, int[]> RetrieveTestCase(int testCaseNumber)
        {
            if (testCaseNumber < 1 || testCaseNumber > input.Length / 2)
                throw new ArgumentOutOfRangeException(nameof(testCaseNumber), "invalid index. Index should count from 1 to number of test cases.");

            int numberOfStudentsRowIndex = (testCaseNumber * 2) - 1;
            int studentRanksRowIndex = numberOfStudentsRowIndex + 1;

            if(!validator.IsNumOfStudentsRowHasValidData(numberOfStudentsRowIndex))
                throw new ArithmeticException($"invalid number of students at row number { numberOfStudentsRowIndex + 1 }");

            int numberOfStudents = Convert.ToInt32(input[numberOfStudentsRowIndex]);

            if(!validator.IsStudentRankRowHasValidData(studentRanksRowIndex, numberOfStudents))
                throw new ArithmeticException($"invalid rank data for students at row number { studentRanksRowIndex + 1 }");

            var studentRanks = TransformStudentRanksString(input[studentRanksRowIndex]);
            return Tuple.Create<int, int[]>(numberOfStudents, studentRanks);
        }

        private int[] TransformStudentRanksString(string ranksString)
        {
            return ranksString.Split(' ').Select<string, int>(int.Parse).ToArray();
        }
    }
}