using Lesson4;

var generator = new RandomUserGenerator();
var users = generator.GenerateRandomUsers();

var report = users.ToList();
foreach (var user in report)
{
    user.Print();
    Console.WriteLine();
}

Console.WriteLine();
var employeeReport = new EmployeeReportGenerator();
var candidateReport = new CandidateReportGenerator();

employeeReport.GenerateReport(report);
Console.WriteLine();
candidateReport.GenerateReport(report);
Console.ReadLine();