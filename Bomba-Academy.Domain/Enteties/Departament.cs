using Bomba_Academy.Domain.BaseEntity;

namespace Bomba_Academy.Domain.Enteties;

public class Departament: BaseEntitiy
{
    public string Name { get; set; }
    public ICollection<Group> Groups { get; set; }
    public ICollection<Teacher> Teachers { get; set; }


}
