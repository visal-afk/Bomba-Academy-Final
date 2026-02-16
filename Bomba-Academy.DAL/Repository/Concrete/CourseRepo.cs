
using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class CourseRepo : BaseRepo<Course>, ICourseRepo
{
    public CourseRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<Course> GetAllWithGroups()
    {
        return _context.Courses
            .Include(c => c.Groups)
            .ToList();
    }
}
