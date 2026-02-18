
using Bomba_Academy.Aplication.Abstract;
using Bomba_Academy.DAL.UOW.Abstract;
using Bomba_Academy.Domain.Enteties;

namespace Bomba_Academy.Aplication.Concrete;


public class TeacherService : IBaseService<Teacher>
{
    protected readonly IUnitOfWork _unitOfWork;
    
    public TeacherService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Create(Teacher entity)
    {
        _unitOfWork.TeacherRepo.Create(entity);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Teacher> GetAll()
    {
        throw new NotImplementedException();
    }

    public Teacher GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id)
    {
        throw new NotImplementedException();
    }
}
