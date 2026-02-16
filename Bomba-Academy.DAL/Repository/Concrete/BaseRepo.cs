using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract.BaseRepos;
using Bomba_Academy.Domain.BaseEntity;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntitiy
{
    protected readonly BombaAcademyDbContext _context;


    public BaseRepo(BombaAcademyDbContext context)
    {
        _context = context;
    }
    public void Create(T entity)
    {
        _context.Add(entity);
       entity.CreatedDate = DateTime.Now;
        
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            entity.IsDeleted = true;
        }
        entity.DeletedDate = DateTime.Now;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().Where(x => !x.IsDeleted).ToList();

    }

    public T GetById(int id)
    {
        return _context.Set<T>().FirstOrDefault(x => x.Id == id && !x.IsDeleted);
    }

    public void Update(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            entity.UpdatedDate = DateTime.Now;
        }

    }
}
