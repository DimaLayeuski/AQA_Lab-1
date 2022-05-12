using System.Collections;
using NUnit.Framework;

namespace TestProject1;

public class DataDiv
{
    public static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData(24, 2).Returns(12);
            yield return new TestCaseData(24, 3).Returns(8);
            yield return new TestCaseData(24, 4).Returns(6);
        }
    }
}