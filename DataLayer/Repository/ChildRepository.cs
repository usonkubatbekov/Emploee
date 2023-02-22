using DataLayer;
using DataLayer.Entityes;
using DomainLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer.Repository
{
    public class ChildRepository : IChildRepository
    {
        private EFDBcontext dbcontext;

        public ChildRepository(EFDBcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public ChildEntity CreateChild(ChildEntity child)
        {
            if (child.Id == 0)
                dbcontext.ChildEntity.Add(child);
            else
                dbcontext.Entry(child).State = EntityState.Modified;

            dbcontext.SaveChanges();

            return child;
        }

        public void DeleteChild(ChildEntity child)
        {
            dbcontext.ChildEntity.Remove(child);
            dbcontext.SaveChanges();
        }

        public List<ChildEntity> GetAllChilds()
        {
            var data = dbcontext.ChildEntity.Where(x => x.Id != null);
            return data.ToList();
        }

        public ChildEntity GetChildById(int childId, bool includeSotrudnik = false)
        {
            if (includeSotrudnik)
                return dbcontext.Set<ChildEntity>().Include(x => x.Sotrudnik).AsNoTracking().FirstOrDefault(x => x.Id == childId);
            else
                return dbcontext.ChildEntity.AsNoTracking().FirstOrDefault(x => x.Id == childId);
        }

        public List<ChildEntity> GetChildBySotrudnikId(int sotrudnikId)
        {
            return dbcontext.ChildEntity.Where(x => x.SotrudnikId == sotrudnikId).ToList();
        }

        public int UpdateChild(ChildEntity child)
        {
            dbcontext.ChildEntity.Update(child);
            dbcontext.SaveChanges();

            return child.Id;
        }



    }
}
