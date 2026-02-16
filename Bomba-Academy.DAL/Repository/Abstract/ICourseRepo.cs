using Bomba_Academy.DAL.Repository.Abstract.BaseRepos;
using Bomba_Academy.Domain.Enteties;

namespace Bomba_Academy.DAL.Repository.Abstract;

public interface ICourseRepo: IBaseRepo<Course>
{
        public IEnumerable<Course> GetAllWithGroups();
}
