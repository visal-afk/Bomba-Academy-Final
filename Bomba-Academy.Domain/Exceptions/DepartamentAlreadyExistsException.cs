namespace Bomba_Academy.Domain.Exceptions;

public class DepartamentAlreadyExistsException : DomainException
{
    public DepartamentAlreadyExistsException(string name)
        : base($"Departament with name '{name}' already exists.")
    {
    }
}

