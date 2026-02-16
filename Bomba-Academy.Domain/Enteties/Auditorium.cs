using Bomba_Academy.Domain.BaseEntity;

namespace Bomba_Academy.Domain.Enteties;

public class Auditorium : BaseEntitiy
{
    public string Name { get; set; } 
    public int Capacity { get; set; }
    public List<Group> Groups { get; set; }
}
