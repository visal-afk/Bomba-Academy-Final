namespace Bomba_Academy.Domain.Exceptions;

public class StudentAlreadyExistsException : DomainException
{
    public StudentAlreadyExistsException(string pin)
        : base($"Student with PIN '{pin}' already exists.")
    {
    }
}

