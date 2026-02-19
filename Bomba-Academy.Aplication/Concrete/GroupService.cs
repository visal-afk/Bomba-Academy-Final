using Bomba_Academy.Aplication.Abstract;
using Bomba_Academy.DAL.UOW.Abstract;
using Bomba_Academy.Domain.DTOs;
using Bomba_Academy.Domain.Enteties;
using Bomba_Academy.Domain.Exceptions;

namespace Bomba_Academy.Aplication.Concrete;

public class GroupService : IBaseService<Group>
{
    protected readonly IUnitOfWork _unitOfWork;
    public GroupService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Create(Group entity)
    {
        var existing = _unitOfWork.GroupRepo
            .GetAll()
            .FirstOrDefault(g => g.Name == entity.Name);

        if (existing != null)
        {
            throw new GroupAlreadyExistsException(entity.Name);
        }

        _unitOfWork.GroupRepo.Create(entity);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        _unitOfWork.GroupRepo.Delete(id);
            _unitOfWork.SaveChanges();
    }

    public IEnumerable<Group> GetAll()
    {
        _unitOfWork.GroupRepo.GetAll();
         return _unitOfWork.GroupRepo.GetAll();
    }

    public Group GetById(int id)
    {
        _unitOfWork.GroupRepo.GetById(id);
         return _unitOfWork.GroupRepo.GetById(id);
    }
    public IEnumerable<GroupInfoDto> GetAllWithCoursesAndAuditoriums() { 
        return _unitOfWork.GroupRepo.GetAllWithCoursesAndAuditoriums();
    }

    public void Update(int id)
    {
        _unitOfWork.GroupRepo.Update(id);
            _unitOfWork.SaveChanges();
    }
}
