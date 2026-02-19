namespace Bomba_Academy.Domain.Exceptions;

public class TeacherAlreadyExistsException : DomainException
{
    public TeacherAlreadyExistsException(string email)
        : base($"Teacher with email '{email}' already exists.")
    {
    }
}

