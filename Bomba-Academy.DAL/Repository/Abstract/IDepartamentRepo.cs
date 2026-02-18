using Bomba_Academy.DAL.Repository.Abstract.BaseRepos;
using Bomba_Academy.Domain.Enteties;
using Bomba_Academy.Domain.DTOs;

namespace Bomba_Academy.DAL.Repository.Abstract;

public interface IDepartamentRepo: IBaseRepo<Departament>
{
        public IEnumerable<DepartamentInfoDto> GetAllWithCoursesAndGroups();
}
