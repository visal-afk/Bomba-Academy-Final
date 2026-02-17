using Bomba_Academy.Domain.BaseEntity;

namespace Bomba_Academy.Domain.Enteties;

public class Subject: BaseEntitiy
{
    public string Name { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public  ICollection<Teacher> Teachers { get; set; }

}
