
using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class StudentRepo : BaseRepo<Student>, IStudentRepo
{
    public StudentRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<Student> GetAllWithGroups()
    {
        return _context.Students
            .Include(s => s.Group)
            .ToList();
    }
}
