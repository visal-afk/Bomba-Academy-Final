using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.DAL.Repository.Concrete;
using Bomba_Academy.DAL.UOW.Abstract;

namespace Bomba_Academy.DAL.UOW.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly BombaAcademyDbContext _context;
    public UnitOfWork(BombaAcademyDbContext context)
    {
        _context = context;
    }
    private IAuditoriumRepo _auditoriumRepo;
    public IAuditoriumRepo AuditoriumRepo => _auditoriumRepo ??= new AuditoriumRepo(_context);
    private ICourseRepo _courseRepo;
    public ICourseRepo CourseRepo => _courseRepo ??= new CourseRepo(_context);
    private IGroupRepo _groupRepo;
    public IGroupRepo GroupRepo => _groupRepo ??= new GroupRepo(_context);
    private IDepartamentRepo _departamentRepo;
    public IDepartamentRepo DepartamentRepo => _departamentRepo ??= new DepartamentRepo(_context);
    private ITeacherRepo _teacherRepo;
    public ITeacherRepo TeacherRepo => _teacherRepo ??= new TeacherRepo(_context);
    private IStudentRepo _studentRepo;
    public IStudentRepo StudentRepo => _studentRepo ??= new StudentRepo(_context);
    private ISubjectRepo _subjectRepo;
    public ISubjectRepo SubjectRepo => _subjectRepo ??= new SubjectRepo(_context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
