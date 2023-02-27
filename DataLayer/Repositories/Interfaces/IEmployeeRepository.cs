using DataLayer.Entities;

namespace DataLayer.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee? GetEmployeeById(int employeeId);

        List<Employee> GetAllEmployees();

        int CreateEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

    }
}
