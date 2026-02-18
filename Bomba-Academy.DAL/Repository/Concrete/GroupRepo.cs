using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace Bomba_Academy.DAL.Repository.Concrete;

public class GroupRepo : BaseRepo<Group>, IGroupRepo
{
    public GroupRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<GroupInfoDto> GetAllWithCoursesAndAuditoriums()
    {

        var conection = _context.Database.GetConnectionString();
        using (var connection = new SqlConnection(conection))
        {
            var query = "SELECT * FROM GetAllWithCoursesAndAuditoriumsView";
            var result = connection.Query<GroupInfoDto>(query).ToList();
            return result;
        }

    }
}
