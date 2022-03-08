namespace Task4;

public interface IReportGenerator
{
    public void GenerateReport(IEnumerable<IPrintable> users);
}