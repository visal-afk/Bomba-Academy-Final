using Bomba_Academy.DAL.Repository.Abstract.BaseRepos;
using System.Text.RegularExpressions;

namespace Bomba_Academy.DAL.Repository.Abstract;

public interface IGroupRepo: IBaseRepo<Group>
{
        public IEnumerable<Group> GetAllWithCoursesAndAuditoriums();
}
