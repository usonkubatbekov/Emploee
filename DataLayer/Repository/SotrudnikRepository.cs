using DataLayer;
using DataLayer.Entityes;
using DomainLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer.Repository
{
    public class SotrudnikRepository : ISotrudnikRepository
    {
        private EFDBcontext dbcontext;

        public SotrudnikRepository(EFDBcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        public SotrudnikEntity GetSotrudnikById(int sotrudnikId, bool includeChilds = false)
        {
            if (includeChilds)
                return dbcontext.Set<SotrudnikEntity>().Include(x => x.Children).AsNoTracking().FirstOrDefault(x => x.Id == sotrudnikId);
            else
                return dbcontext.Sotrudnikis.AsNoTracking().FirstOrDefault(x => x.Id == sotrudnikId);
        }

        public List<SotrudnikEntity> GetAllSotrudniks()
        {
            return dbcontext.Sotrudnikis.Where(x => x.Id != null).ToList();
        }

        public int CreateSotrudnik(SotrudnikEntity sotrudnik)
        {
            if (sotrudnik.Id == 0)
                dbcontext.Sotrudnikis.Add(sotrudnik);
            else
                dbcontext.Entry(sotrudnik).State = EntityState.Modified;

            dbcontext.SaveChanges();

            return sotrudnik.Id;
        }

        public void DeleteSotrudnik(SotrudnikEntity sotrudnik)
        {

            dbcontext.Sotrudnikis.Remove(sotrudnik);
            dbcontext.SaveChanges();
        }

        public int UpdateSotrudnik(SotrudnikEntity sotrudnik)
        {
            
            dbcontext.Sotrudnikis.Update(sotrudnik);
            dbcontext.SaveChanges();
            
            return sotrudnik.Id;
        }
    }
}
