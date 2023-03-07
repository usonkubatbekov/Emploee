using ServiceLayer.Managers.Interface;
using ServiceLayer.Services;
using ServiceLayer.Services.Interface;

namespace ServiceLayer.Managers
{
    public class ServicesManager : IServicesManager
    {
        private readonly IEmployeeService _employeeService;
        private readonly IChildService _childService;
        private readonly IPositionService _positionService;

        public ServicesManager(IEmployeeService employeeService, IChildService childService, IPositionService positionService)
        {
            _employeeService = employeeService;
            _childService = childService;
            _positionService = positionService;
        }

        public EmployeeService EmployeeService { get { return (EmployeeService)_employeeService; } }
        public ChildService ChildService { get { return (ChildService)_childService; } }
        public PositionService PositionService { get { return (PositionService)_positionService; } }
    }
}
