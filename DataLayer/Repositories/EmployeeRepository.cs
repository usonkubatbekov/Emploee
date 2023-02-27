using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeEFDBcontext _dbcontext;

        public EmployeeRepository(EmployeeEFDBcontext dbcontext)
        {
            this._dbcontext = dbcontext;
        }


        public Employee? GetEmployeeById(int employeeId)
        {
            return _dbcontext.Employees!.AsNoTracking<Employee>().FirstOrDefault(x => x.Id == employeeId);
        }

        public List<Employee> GetAllEmployees()
        {
            return _dbcontext.Employees.ToList();
        }

        public int CreateEmployee(Employee employee)
        {
            _dbcontext.Employees.Add(employee);
            _dbcontext.SaveChanges();
            return employee.Id;
        }

        public void DeleteEmployee(Employee employee)
        {
            _dbcontext.Employees.Remove(employee);
            _dbcontext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            
            _dbcontext.Employees.Update(employee);
            _dbcontext.SaveChanges();
        }
    }
}
