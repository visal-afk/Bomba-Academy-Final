using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract.BaseRepos;
using Bomba_Academy.Domain.BaseEntity;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        var connectionString = _context.Database.GetConnectionString();
        using(var connection = new SqlConnection(connectionString))
        {
            var sql = $"SELECT * FROM {typeof(T).Name}s WHERE IsDeleted = 0";
            var result = connection.Query<T>(sql);
            return result;
        }

    }

    public T GetById(int id)
    {
        var connectionString = _context.Database.GetConnectionString();
        using(var connection = new SqlConnection(connectionString))
        {
            var sql = $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id AND IsDeleted = 0";
            var result = connection.QueryFirstOrDefault<T>(sql, new { Id = id });
            return result;
        }
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
