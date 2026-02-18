namespace Bomba_Academy.Aplication.Abstract;
using Bomba_Academy.Domain.BaseEntity;


public interface IBaseService<T> where T : BaseEntitiy
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Create(T entity);
    void Update(int id);
    void Delete(int id);
}
