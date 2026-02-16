using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class TeacherRepo : BaseRepo<Teacher>, ITeacherRepo
{
    public TeacherRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<Teacher> GetAllWithSubjects()
    {
        return _context.Teachers.Include(t => t.TeacherSubjects).ThenInclude(ts => ts.Subject).ToList();
    }
}
