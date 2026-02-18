using Bomba_Academy.DAL.Repository.Abstract;

namespace Bomba_Academy.DAL.UOW.Abstract;

public interface IUnitOfWork: IDisposable
{
    IAuditoriumRepo AuditoriumRepo{ get; }
    ICourseRepo CourseRepo { get; }
    IGroupRepo GroupRepo { get; }
    IDepartamentRepo DepartamentRepo { get; }
    ITeacherRepo TeacherRepo { get; }
    IStudentRepo StudentRepo { get; }
    ISubjectRepo SubjectRepo { get; }
    int SaveChanges();




}
