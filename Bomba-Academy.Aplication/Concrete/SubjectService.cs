using Bomba_Academy.Aplication.Abstract;
using Bomba_Academy.DAL.UOW.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Bomba_Academy.Domain.Exceptions;

namespace Bomba_Academy.Aplication.Concrete;

public class SubjectService : IBaseService<Subject>
{
    protected readonly IUnitOfWork _unitOfWork;
    public SubjectService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Create(Subject entity)
    {
        var existing = _unitOfWork.SubjectRepo
            .GetAll()
            .FirstOrDefault(s => s.Name == entity.Name && s.CourseId == entity.CourseId);

        if (existing != null)
        {
            throw new SubjectAlreadyExistsException(entity.Name);
        }

        _unitOfWork.SubjectRepo.Create(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        _unitOfWork.SubjectRepo.Delete(id);
        _unitOfWork.SaveChanges();

    }

    public IEnumerable<Subject> GetAll()
    {
        return _unitOfWork.SubjectRepo.GetAll();

    }

    public Subject GetById(int id)
    {
        return _unitOfWork.SubjectRepo.GetById(id);
    }
    public IEnumerable<SubjectInfoDto> GetAllWithCourses() { 
        return _unitOfWork.SubjectRepo.GetAllWithCourses();
    }

    public void Update(int id)
    {
        _unitOfWork.SubjectRepo.Update(id);
        _unitOfWork.SaveChanges();
    }
}
