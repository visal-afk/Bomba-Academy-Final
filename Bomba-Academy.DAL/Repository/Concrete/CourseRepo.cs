
using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class CourseRepo : BaseRepo<Course>, ICourseRepo
{
    public CourseRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<CourseInfoDto> GetAllWithGroups()
    {
        var conection = _context.Database.GetConnectionString();
        using (var connection = new SqlConnection(conection))
        {
            var query = "SELECT * FROM GetAllWithGroupsView";
            var result = connection.Query<CourseInfoDto>(query).ToList();
            return result;
        }

    }
}
