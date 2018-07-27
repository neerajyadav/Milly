using System.Linq;

namespace Milly
{
    public class ThinkingUnitCalculator
    {
        public static int NumberOfThinkingUnitsUsed(int numberOfStudents, int[] ranks)
        {
            //using gauss formula to calculate sum of numbers of students.
            int sumOfNumbersOfStudents = (numberOfStudents * (numberOfStudents + 1)) / 2;
            int sumOfRanksOfStudents = ranks.Sum();

            int numberOfThinkingUnitsUsed = sumOfNumbersOfStudents - sumOfRanksOfStudents;
            //there can be scenarios where sumOfRanksOfStudents can be greater than sumOfNumbersOfStudents. In that case we only need to convert negative value to positive. 
            if (numberOfThinkingUnitsUsed < 0)
            {
                numberOfThinkingUnitsUsed = numberOfThinkingUnitsUsed * (-1);
            }

            return numberOfThinkingUnitsUsed;
        }
    }
}