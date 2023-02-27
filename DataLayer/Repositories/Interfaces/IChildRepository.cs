using DataLayer.Entities;

namespace DataLayer.Repositories.Interfaces
{
    public interface IChildRepository
    {
        Child? GetChildById(int childId);

        List<Child?> GetAllChilds();

        Child? CreateChild(Child child);

        void UpdateChild(Child child);

        void DeleteChild(Child child);

        List<Child?> GetChildByEmployeeId(int employeeId);
    }
}
