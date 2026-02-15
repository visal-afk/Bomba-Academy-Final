using Bomba_Academy.Domain.BaseEntity;

namespace Bomba_Academy.Domain.Enteties;

public class Student : BaseEntitiy
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Pin { get; set; }
    public decimal Gpa { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
}
