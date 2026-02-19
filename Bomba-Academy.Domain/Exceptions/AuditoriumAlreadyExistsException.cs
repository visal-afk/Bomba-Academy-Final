namespace Bomba_Academy.Domain.Exceptions;

public class AuditoriumAlreadyExistsException : DomainException
{
    public AuditoriumAlreadyExistsException(string name)
        : base($"Auditorium with name '{name}' already exists.")
    {
    }
}

