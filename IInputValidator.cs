namespace Milly
{
    public interface IInputValidator
    {
        bool IsTestCasesNumberValid();
        bool IsCountOfWrittenTestCasesValid();
        bool IsNumOfStudentsRowHasValidData(int index);
        bool IsStudentRankRowHasValidData(int index, int numOfStudents);
        bool ValidateTestCase(int studentCount, int[] ranks);
    }
}