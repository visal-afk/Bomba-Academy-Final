using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Bomba_Academy.DAL.Repository.Concrete;

public class DepartamentRepo : BaseRepo<Departament>, IDepartamentRepo
{
    public DepartamentRepo(BombaAcademyDbContext context) : base(context)
    {
    }

    public IEnumerable<Departament> GetAllWithCoursesAndGroups()
    {
        return _context.Departaments
            .Include(d => d.Groups)
            .ThenInclude(g => g.Course)
            .ToList();

    }
}
