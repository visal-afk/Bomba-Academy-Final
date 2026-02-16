using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;


namespace Bomba_Academy.DAL.Repository.Concrete;

public class GroupRepo : BaseRepo<Group>, IGroupRepo
{
    public GroupRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<Group> GetAllWithCoursesAndAuditoriums()
    {
        return _context.Groups
            .Include(g => g.Course)
            .Include(g => g.Auditorium)
            .ToList();
    }
}
