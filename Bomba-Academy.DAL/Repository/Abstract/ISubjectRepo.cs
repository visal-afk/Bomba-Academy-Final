using Bomba_Academy.DAL.Repository.Abstract.BaseRepos;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;

namespace Bomba_Academy.DAL.Repository.Abstract;

public interface ISubjectRepo: IBaseRepo<Subject>
{
    public IEnumerable<SubjectInfoDto> GetAllWithCourses();
}
