namespace Task4;

public class CandidateReportGenerator : IReportGenerator
{
    public void GenerateReport(IEnumerable<IPrintable> users)
    {
        var sorted = users.OfType<Candidate>().OrderBy(c=>c.JobSalary)
            .ThenByDescending(c => c.JobTittle);
        foreach (var candidate in sorted)
        {
            Console.WriteLine($"{candidate.UserId} || {candidate.FirstName} {candidate.LastName} || " +
                              $"{candidate.JobTittle} || {candidate.JobSalary}");
        }
    }
}