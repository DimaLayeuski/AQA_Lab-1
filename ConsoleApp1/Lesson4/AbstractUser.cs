namespace Lesson4;

public abstract class AbstractUser
{
    protected internal Guid UserId;
    protected internal readonly string? FirstName;
    protected internal readonly string? LastName;

    protected AbstractUser(Guid userId, string? firstName, string? lastName)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
    }
    
}