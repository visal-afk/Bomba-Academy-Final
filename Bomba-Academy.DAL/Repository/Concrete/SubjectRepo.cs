using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class SubjectRepo : BaseRepo<Subject>, ISubjectRepo
{
    public SubjectRepo(BombaAcademyDbContext context) : base(context)
    { 
    }

    public IEnumerable<Subject> GetAllWithCourses()
    {
        return _context.Subjects.Include(s => s.Course).ToList();
    }
}
