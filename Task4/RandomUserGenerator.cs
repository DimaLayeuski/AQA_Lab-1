namespace Lesson4;
public class RandomUserGenerator
{
    private static readonly Random Rnd = new Random();
    private readonly int _employeeCount = Rnd.Next(5,10);
    private readonly int _candidateCount = Rnd.Next(5,10);
    public IEnumerable<IPrintable> GenerateRandomUsers()
    {
        var usersCollection = new List<IPrintable?>();
        
        for (var i = 0; i < _employeeCount; i++)
        {
            usersCollection.Add(UserFactory.Generate(UserType.Employee));
        }
        
        for (var i = 0; i < _candidateCount; i++)
        {
            usersCollection.Add(UserFactory.Generate(UserType.Candidate));
        }
        
        return usersCollection!;
    }
}