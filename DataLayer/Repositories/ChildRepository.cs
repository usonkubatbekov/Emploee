using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private readonly EmployeeEFDBcontext _dbcontext;

        public ChildRepository(EmployeeEFDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Child? CreateChild(Child child)
        {
            _dbcontext.Childrens.Add(child);
            _dbcontext.SaveChanges();
            return child;
        }

        public void DeleteChild(Child child)
        {
            _dbcontext.Childrens.Remove(child);
            _dbcontext.SaveChanges();
        }

        public List<Child?> GetAllChilds()
        {
            var data = _dbcontext.Childrens;
            return data.ToList();
        }

        public Child? GetChildById(int childId)
        {
            return _dbcontext.Childrens!.AsNoTracking<Child>().FirstOrDefault(x => x.Id == childId);
        }

        public List<Child?> GetChildByEmployeeId(int employeeId)
        {
            return _dbcontext.Childrens.Where(x => x != null && x.EmployeeId == employeeId).ToList();
        }

        public void UpdateChild(Child child)
        {
            _dbcontext.Childrens.Update(child);
            _dbcontext.SaveChanges();
        }
    }
}
