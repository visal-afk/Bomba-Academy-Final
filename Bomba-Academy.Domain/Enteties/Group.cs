using Bomba_Academy.Domain.BaseEntity;

namespace Bomba_Academy.Domain.Enteties;

public class Group: BaseEntitiy
{
    public string Name { get; set; }
    public int CourseId { get; set; }
    public int DepartmentId { get; set; }
    public int AuditoriumId { get; set; } 
    public Auditorium Auditorium { get; set; }
    public ICollection<Student> Students { get; set; }
    public Departament Departament { get; set; }
    public Course Course { get; set; }
    

}
