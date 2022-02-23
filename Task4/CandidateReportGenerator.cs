namespace Lesson4;

public class CandidateReportGenerator : IReportGenerator
{
    public void GenerateReport(IEnumerable<IPrintable> users)
    {
        var sorted = users.OfType<Candidate>().OrderBy(c=>c.JobTittle)
            .ThenByDescending(c => c.JobSalary);
        foreach (var candidate in sorted)
        {
            Console.WriteLine($"{candidate.UserId} || {candidate.FirstName} {candidate.LastName} || " +
                              $"{candidate.JobTittle} || {candidate.JobSalary}");
        }
    }
}