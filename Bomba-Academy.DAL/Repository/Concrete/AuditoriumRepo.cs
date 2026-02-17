using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class AuditoriumRepo : BaseRepo<Auditorium>, IAuditoriumRepo
{
    public AuditoriumRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<AuditorimInfoDto> GetAllWithCoursesAndGroup()
    {
        var auditoriums = _context.Auditoriums
            .Include(a => a.Groups)
            .ThenInclude(g => g.Course)
            .Select(a => new AuditorimInfoDto
            {
                Id = a.Id,
                Name = a.Name,
                GroupName = a.Groups.FirstOrDefault().Name,
                Course = a.Groups.FirstOrDefault().Course != null ? a.Groups.FirstOrDefault().Course.Id : (int?)null
            })
            .ToList();
        return auditoriums;


    }
}
