using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using ServiceLayer.Managers.Interface;

namespace ServiceLayer.Managers
{
    public class DataManager : IDataManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IChildRepository _childRepository;
        private readonly IPositionRepository _positionRepository;

        public DataManager(IEmployeeRepository employeeRepository, IChildRepository childRepository, IPositionRepository positionRepository)
        {
            _employeeRepository = employeeRepository;
            _childRepository = childRepository;
            _positionRepository = positionRepository;
        }

        public EmployeeRepository EmployeeRepo { get { return (EmployeeRepository) _employeeRepository; } }

        public ChildRepository ChildRepo { get { return (ChildRepository) _childRepository; } }

        public PositionRepository PositionRepo { get { return (PositionRepository) _positionRepository; } }

    }
}
