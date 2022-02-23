namespace Lesson4;

public class EmployeeReportGenerator : IReportGenerator
{
    public void GenerateReport(IEnumerable<IPrintable> users)
    {
        var sorted = users.OfType<Employee>().OrderBy(x => x.CompanyName)
            .ThenByDescending(x => x.JobSalary);
        foreach (var employee in sorted)
        {
            Console.WriteLine($"{employee.UserId} || {employee.CompanyName} || " +
                              $"{employee.FirstName} {employee.LastName} || {employee.JobSalary}");
        }
    }
}