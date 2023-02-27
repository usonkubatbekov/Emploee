using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.Dtos;
using ServiceLayer.Managers.Interface;
using ServiceLayer.Services.Interface;

namespace ServiceLayer.Services
{
    public class ChildService : IChildService
    {
        private readonly IDataManager _dataManager;
        private readonly IMapper _mapper;

        public ChildService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public List<ChildDtoForIndex> GetAllChilds()
        {
            return _mapper.Map<List<ChildDtoForIndex>>(_dataManager.ChildRepo.GetAllChilds());
        }

        public ChildDto GetChildById(int employee)
        {
            return _mapper.Map<ChildDto>(_dataManager.ChildRepo.GetChildById(employee));
        }

        public List<ChildDto> GetChildListByEmployeeId(int employeeId)
        {
            return _mapper.Map<List<ChildDto>>(_dataManager.ChildRepo.GetChildByEmployeeId(employeeId));
        }

        public ChildDto SaveChild(ChildDto dto)
        {
            Child? child = new Child();

            child.Surname = dto.Surname;
            child.Name = dto.Name;
            child.Lastname = dto.Lastname;
            child.Birthday = dto.BirthDay;
            child.EmployeeId = dto.EmployeeId;
            
            var createdchild = _dataManager.ChildRepo.CreateChild(child);

            return _mapper.Map<ChildDto>(createdchild);
        }

        public ChildDto UpdateChild(ChildDto dto)
        {
            Child? child;

            child = _mapper.Map<Child>(dto);

            _dataManager.ChildRepo.UpdateChild(child);

            return dto;
        }

        public ChildDto DeleteChildById(ChildDto dto)
        {
            Child? child;

            child = _mapper.Map<Child>(dto);

            _dataManager.ChildRepo.DeleteChild(child);

            return dto;
        }
    }
}
