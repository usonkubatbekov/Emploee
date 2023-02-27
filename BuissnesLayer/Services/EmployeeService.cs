using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.Dtos;
using ServiceLayer.Managers.Interface;
using ServiceLayer.Services.Interface;

namespace ServiceLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataManager _dataManager;
        private readonly IMapper _mapper;

        public EmployeeService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        
         public EmployeeDto GetEmployeeById(int employeeId)
         {
             return _mapper.Map<EmployeeDto>(_dataManager.EmployeeRepo.GetEmployeeById(employeeId));           
         }

         public List<EmloyeeDtoforIndex> GetAllEmployees()
         {
             return _mapper.Map<List<EmloyeeDtoforIndex>>(_dataManager.EmployeeRepo.GetAllEmployees());
         }

         public EmployeeDto SaveEmployee(EmployeeDto dto)
         {
             Employee? employee;

             if (dto.Id != 0) 
             {
                 employee = _dataManager.EmployeeRepo.GetEmployeeById(dto.Id);
             }
             else 
             {
                 employee = new Employee();
             }

             employee.Surname = dto.Surname;
             employee.Name = dto.Name;
             employee.Lastname = dto.Lastname;
             employee.Birthday = dto.BirthDay;
             employee.Position = dto.Position;  

             _dataManager.EmployeeRepo.CreateEmployee(employee);

             return _mapper.Map<EmployeeDto>(employee);
         }

         public EmployeeDto UpdateEmployee(EmployeeDto dto) 
         {
             var employee = _mapper.Map<Employee>(dto);
            _dataManager.EmployeeRepo.UpdateEmployee(employee);
            
            return dto;
         }

        public EmployeeDto DeleteEmployeeById(EmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            _dataManager.EmployeeRepo.DeleteEmployee(employee);

            return dto;
        }

    }
}
