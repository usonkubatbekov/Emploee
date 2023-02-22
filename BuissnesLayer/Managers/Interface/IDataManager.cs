using DomainLayer.Repository;

namespace ServiceLayer.Managers.Interface
{
    public interface IDataManager
    {
        SotrudnikRepository SotrudnikRepo { get; }
        ChildRepository ChildRepo { get; }
    }
}
