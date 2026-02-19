using Bomba_Academy.Aplication.Abstract;
using Bomba_Academy.DAL.Repository.Abstract;
using Bomba_Academy.DAL.UOW.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Bomba_Academy.Domain.Exceptions;
using System.Collections.Generic;

namespace Bomba_Academy.Aplication.Concrete;

public class CourseService : IBaseService<Course>
{
    protected readonly IUnitOfWork _unitOfWork;
    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Create(Course entity)
    {
        var existing = _unitOfWork.CourseRepo
            .GetAll()
            .FirstOrDefault(c => c.CourseNumber == entity.CourseNumber);

        if (existing != null)
        {
            throw new CourseAlreadyExistsException(entity.CourseNumber);
        }

        _unitOfWork.CourseRepo.Create(entity);
        _unitOfWork.SaveChanges();

    }

    public void Delete(int id)
    {
        _unitOfWork.CourseRepo.Delete(id);
            _unitOfWork.SaveChanges();

    }

    public IEnumerable<Course> GetAll()
    {
        return _unitOfWork.CourseRepo.GetAll();

    }
    public IEnumerable<CourseInfoDto> GetAllWithGroups()
    {
        return _unitOfWork.CourseRepo.GetAllWithGroups();
    }

    public Course GetById(int id)
    {
        return _unitOfWork.CourseRepo.GetById(id);

    }

    public void Update(int id)
    {
        _unitOfWork.CourseRepo.Update(id);
            _unitOfWork.SaveChanges();

    }
}
