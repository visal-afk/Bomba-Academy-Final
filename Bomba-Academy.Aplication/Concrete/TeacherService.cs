
using Bomba_Academy.Aplication.Abstract;
using Bomba_Academy.DAL.UOW.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Bomba_Academy.Domain.Exceptions;

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
        var existing = _unitOfWork.TeacherRepo
            .GetAll()
            .FirstOrDefault(t => t.Email == entity.Email);

        if (existing != null)
        {
            throw new TeacherAlreadyExistsException(entity.Email);
        }

        _unitOfWork.TeacherRepo.Create(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        _unitOfWork.TeacherRepo.Delete(id);
        _unitOfWork.SaveChanges();
    }

    public IEnumerable<Teacher> GetAll()
    {
        return _unitOfWork.TeacherRepo.GetAll();
    }

    public Teacher GetById(int id)
    {
        return _unitOfWork.TeacherRepo.GetById(id);
    }

    public void Update(int id)
    {
        _unitOfWork.TeacherRepo.Update(id);
        _unitOfWork.SaveChanges();
    }

    public IEnumerable<TeacherInfoDto> GetAllWithSubjects()
    {
        return _unitOfWork.TeacherRepo.GetAllWithSubjects();
    }
}
