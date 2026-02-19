using Bomba_Academy.Aplication.Abstract;
using Bomba_Academy.DAL.UOW.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Bomba_Academy.Domain.Exceptions;

namespace Bomba_Academy.Aplication.Concrete;

public class StudentService : IBaseService<Student>
{
    protected readonly IUnitOfWork _unitOfWork;
    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Create(Student entity)
    {
        var existing = _unitOfWork.StudentRepo
            .GetAll()
            .FirstOrDefault(s => s.Pin == entity.Pin);

        if (existing != null)
        {
            throw new StudentAlreadyExistsException(entity.Pin);
        }

        _unitOfWork.StudentRepo.Create(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        _unitOfWork.StudentRepo.Delete(id);
            _unitOfWork.SaveChanges();
    }

    public IEnumerable<Student> GetAll()
    {
        
          return _unitOfWork.StudentRepo.GetAll();
    }
    public IEnumerable<StudentInfoDto> GetAllWithGroups()
    {
        return _unitOfWork.StudentRepo.GetAllWithGroups();
    }

    public Student GetById(int id)
    {
        return _unitOfWork.StudentRepo.GetById(id);
            
    }

    public void Update(int id)
    {
        _unitOfWork.StudentRepo.Update(id);
            _unitOfWork.SaveChanges();
    }
}
