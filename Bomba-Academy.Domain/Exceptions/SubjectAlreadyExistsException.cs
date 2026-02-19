namespace Bomba_Academy.Domain.Exceptions;

public class SubjectAlreadyExistsException : DomainException
{
    public SubjectAlreadyExistsException(string name)
        : base($"Subject with name '{name}' already exists.")
    {
    }
}

