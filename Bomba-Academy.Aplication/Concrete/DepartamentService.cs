using Bomba_Academy.Aplication.Abstract;
using Bomba_Academy.DAL.UOW.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;

namespace Bomba_Academy.Aplication.Concrete;

public class DepartamentService : IBaseService<Departament>
{
    protected readonly IUnitOfWork _unitOfWork;
    public DepartamentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Create(Departament entity)
    {
        _unitOfWork.DepartamentRepo.Create(entity);
    }

    public void Delete(int id)
    {
        _unitOfWork.DepartamentRepo.Delete(id);
             _unitOfWork.SaveChanges();
    }

    public IEnumerable<Departament> GetAll()
    { 
             return _unitOfWork.DepartamentRepo.GetAll();
    }

    public Departament GetById(int id)
    {
        return _unitOfWork.DepartamentRepo.GetById(id);

    }
    public IEnumerable<DepartamentInfoDto> GetAllWithCoursesAndGroups()
    {
         return _unitOfWork.DepartamentRepo.GetAllWithCoursesAndGroups();
    }
    public void Update(int id)
    {
        _unitOfWork.DepartamentRepo.Update(id);
             _unitOfWork.SaveChanges();
    }
}
