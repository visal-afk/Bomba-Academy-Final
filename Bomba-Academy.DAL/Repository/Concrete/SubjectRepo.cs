using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class SubjectRepo : BaseRepo<Subject>, ISubjectRepo
{
    public SubjectRepo(BombaAcademyDbContext context) : base(context)
    { 
    }

    public IEnumerable<SubjectInfoDto> GetAllWithCourses()
    {
        var conection = _context.Database.GetConnectionString();
        using(var connection = new SqlConnection(conection))
        {
            var sql = @"SELECT * FROM GetAllWithCoursesView";
            var result = connection.Query<SubjectInfoDto>(sql).ToList();
            return result;
        }
    }
}
