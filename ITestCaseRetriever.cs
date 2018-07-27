using System;

namespace Milly
{
    public interface ITestCaseRetriever
    {
        Tuple<int, int[]> RetrieveTestCase(int index);
    }
}