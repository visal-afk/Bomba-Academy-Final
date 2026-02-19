using Bomba_Academy.Aplication.Abstract;
using Bomba_Academy.DAL.UOW.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Bomba_Academy.Domain.Exceptions;
namespace Bomba_Academy.Aplication.Concrete;

public class AuditoriumService : IBaseService<Auditorium>
{
    protected readonly IUnitOfWork _unitOfWork;
    public AuditoriumService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Create(Auditorium entity)
    {
        var existing = _unitOfWork.AuditoriumRepo
            .GetAll()
            .FirstOrDefault(a => a.Name == entity.Name);

        if (existing != null)
        {
            throw new AuditoriumAlreadyExistsException(entity.Name);
        }

        _unitOfWork.AuditoriumRepo.Create(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        _unitOfWork.AuditoriumRepo.Delete(id);
            _unitOfWork.SaveChanges();

    }

    public IEnumerable<Auditorium> GetAll()
    {
        return _unitOfWork.AuditoriumRepo.GetAll();

    }

    public Auditorium GetById(int id)
    {
        return _unitOfWork.AuditoriumRepo.GetById(id);

    }
    public IEnumerable<AuditorimInfoDto> GetAllWithCoursesAndGroup()
    {
        return _unitOfWork.AuditoriumRepo.GetAllWithCoursesAndGroup();
    }

    public void Update(int id)
    {
        _unitOfWork.AuditoriumRepo.Update(id);
            _unitOfWork.SaveChanges();

    }
}
