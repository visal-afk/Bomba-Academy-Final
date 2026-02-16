using Bomba_Academy.DAL.Repository.Abstract.BaseRepos;
using Bomba_Academy.Domain.Enteties;

namespace Bomba_Academy.DAL.Repository.Abstract;

public interface IStudentRepo: IBaseRepo<Student>
{
        public IEnumerable<Student> GetAllWithGroups();

}
