using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repository.Interfaces
{
    public interface IChildRepository
    {
        ChildEntity GetChildById(int childId, bool includeSotrudnik = false);

        List<ChildEntity> GetAllChilds();

        ChildEntity CreateChild(ChildEntity child);

        int UpdateChild(ChildEntity child);

        void DeleteChild(ChildEntity child);

        List<ChildEntity> GetChildBySotrudnikId(int sotrudnikId);
    }
}
