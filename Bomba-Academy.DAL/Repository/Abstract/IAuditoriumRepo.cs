using Bomba_Academy.DAL.Repository.Abstract.BaseRepos;
using Bomba_Academy.Domain.Enteties;

namespace Bomba_Academy.DAL.Repository.Abstract;

public interface IAuditoriumRepo: IBaseRepo<Auditorium>
{
    public IEnumerable<Auditorium> GetAllWithCoursesAndGroup();
}
