using ServiceLayer.Dtos;

namespace ServiceLayer.Services.Interface
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmployeeById(int employeeId);
        List<EmloyeeDtoforIndex> GetAllEmployees();
        EmployeeDto SaveEmployee(EmployeeDto dto);
        EmployeeDto UpdateEmployee(EmployeeDto dto);
        EmployeeDto DeleteEmployeeById(EmployeeDto dto);
    }
}
