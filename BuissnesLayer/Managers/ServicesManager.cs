using ServiceLayer.Managers.Interface;
using ServiceLayer.Services;
using ServiceLayer.Services.Interface;

namespace ServiceLayer.Managers
{
    public class ServicesManager : IServicesManager
    {
        private readonly IEmployeeService _employeeService;
        private readonly IChildService _childService;

        public ServicesManager(IEmployeeService employeeService, IChildService childService)
        {
            _employeeService = employeeService;
            _childService = childService;
        }

        public EmployeeService EmployeeService { get { return (EmployeeService)_employeeService; } }
        public ChildService ChildService { get { return (ChildService)_childService; } }
    }
}
