using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using ServiceLayer.Managers.Interface;

namespace ServiceLayer.Managers
{
    public class DataManager : IDataManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IChildRepository _childRepository;

        public DataManager(IEmployeeRepository employeeRepository, IChildRepository childRepository)
        {
            _employeeRepository = employeeRepository;
            _childRepository = childRepository;
        }

        public EmployeeRepository EmployeeRepo { get { return (EmployeeRepository) _employeeRepository; } }

        public ChildRepository ChildRepo { get { return (ChildRepository) _childRepository; } }
    }
}
