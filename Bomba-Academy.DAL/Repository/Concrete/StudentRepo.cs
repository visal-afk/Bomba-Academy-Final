
using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class StudentRepo : BaseRepo<Student>, IStudentRepo
{
    public StudentRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<StudentInfoDto> GetAllWithGroups()
    {
        
        var conection = _context.Database.GetConnectionString();
        using (var connection = new SqlConnection(conection))
        {
            connection.Open();
            var result = connection.Query<StudentInfoDto>(@"SELECT * FROM GetStudentsWithGroupsView");
            return result;
        }
    }
}
