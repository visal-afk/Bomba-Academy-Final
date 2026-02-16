namespace Bomba_Academy.DAL.Repository.Abstract.BaseRepos;

public interface IBaseRepo<T>where T:class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Create(T entity);
    void Update(int id);
    void Delete(int id);

}
