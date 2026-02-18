using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class AuditoriumRepo : BaseRepo<Auditorium>, IAuditoriumRepo
{
    public AuditoriumRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<AuditorimInfoDto> GetAllWithCoursesAndGroup()
    {
       
        var conectionString = _context.Database.GetConnectionString();
        using (var connection = new SqlConnection(conectionString))
        {
            var sql = "SELECT * FROM GetAllWithCoursesAndGroupView";
            var result = connection.Query<AuditorimInfoDto>(sql).ToList();
            return result;


        }
    }
}
