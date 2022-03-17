namespace Task4;

public class RandomUserGenerator
{
    private static readonly Random Rnd = new();
    private readonly int _employeeCount = Rnd.Next(5, 10);
    private readonly int _candidateCount = Rnd.Next(5, 10);

    public IEnumerable<IPrintable> GenerateRandomUsers()
    {
        var usersCollection = new List<IPrintable?>();
        AddToColection(usersCollection, _employeeCount, UserType.Employee);
        AddToColection(usersCollection, _candidateCount, UserType.Candidate);
        return usersCollection!;
    }

    private void AddToColection(List<IPrintable?> collection, int count, UserType userType)
    {
        for (var i = 0; i < count; i++)
        {
            collection.Add(UserFactory.Generate(userType));
        }
    }
}