using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class DepartamentRepo : BaseRepo<Departament>, IDepartamentRepo
{
    public DepartamentRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<DepartamentInfoDto> GetAllWithCoursesAndGroups()
    {
        var conection = _context.Database.GetConnectionString();
        using (var connection = new SqlConnection(conection))
        {
            var query = "SELECT * FROM GetDepartamentsWithCoursesAndGroupsView";
            var result = connection.Query<DepartamentInfoDto>(query).ToList();
            return result;
        }

    }
}
