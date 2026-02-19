namespace Bomba_Academy.Domain.Exceptions;

public class GroupAlreadyExistsException : DomainException
{
    public GroupAlreadyExistsException(string name)
        : base($"Group with name '{name}' already exists.")
    {
    }
}

