using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class AuditoriumRepo : BaseRepo<Auditorium>, IAuditoriumRepo
{
    public AuditoriumRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<Auditorium> GetAllWithCoursesAndGroup()
    {
        return _context.Auditoriums
            .Include(a => a.Groups)
            .ThenInclude(g => g.Course)
            .ToList();

    }
}
