using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class TeacherRepo : BaseRepo<Teacher>, ITeacherRepo
{
    public TeacherRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<TeacherInfoDto> GetAllWithSubjects()
    {
        
        var conection = _context.Database.GetConnectionString();
        using(var connection = new SqlConnection(conection))
        {
            var sql = @"SELECT * FROM GetAllWithSubjectsView";
            var result = connection.Query<TeacherInfoDto>(sql);
            return result;
        }
    }
}
