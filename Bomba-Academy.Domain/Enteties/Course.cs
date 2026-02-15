using Bomba_Academy.Domain.BaseEntity;

namespace Bomba_Academy.Domain.Enteties;

public class Course: BaseEntitiy
{
    public int CourseNumber { get; set; }
    public ICollection<Group> Groups { get; set; }

}
