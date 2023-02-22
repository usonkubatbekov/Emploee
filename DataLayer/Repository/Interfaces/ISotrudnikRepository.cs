using DataLayer.Entityes;

namespace DomainLayer.Repository.Interfaces
{
    public interface ISotrudnikRepository
    {
        //List<SotrudnikEntity> GetAllSotrudnik(bool includechilds = false);

        SotrudnikEntity GetSotrudnikById(int sotrudnikId, bool includeChilds = false);

        List<SotrudnikEntity> GetAllSotrudniks();

        int CreateSotrudnik(SotrudnikEntity sotrudnik);

        int UpdateSotrudnik(SotrudnikEntity sotrudnik);

        void DeleteSotrudnik(SotrudnikEntity sotrudnik);

    }
}
