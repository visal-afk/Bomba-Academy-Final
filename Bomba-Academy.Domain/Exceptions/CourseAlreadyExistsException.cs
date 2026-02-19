namespace Bomba_Academy.Domain.Exceptions;

public class CourseAlreadyExistsException : DomainException
{
    public CourseAlreadyExistsException(int courseNumber)
        : base($"Course with number '{courseNumber}' already exists.")
    {
    }
}

