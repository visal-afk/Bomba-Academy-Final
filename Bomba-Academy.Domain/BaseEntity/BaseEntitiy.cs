namespace Bomba_Academy.Domain.BaseEntity;

public  class BaseEntitiy
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}
