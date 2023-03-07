using DataLayer.Repositories;

namespace ServiceLayer.Managers.Interface
{
    public interface IDataManager
    {
        EmployeeRepository EmployeeRepo { get; }
        ChildRepository ChildRepo { get; }
        PositionRepository PositionRepo { get; }

    }
}
