using ServiceLayer.Services;

namespace ServiceLayer.Managers.Interface
{
    public interface IServicesManager
    {
        EmployeeService EmployeeService { get; }
        ChildService ChildService { get; }
        PositionService PositionService { get; }
    }
}
