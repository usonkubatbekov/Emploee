using DomainLayer.Repository;
using DomainLayer.Repository.Interfaces;
using ServiceLayer.Managers.Interface;

namespace ServiceLayer.Managers
{
    public class DataManager : IDataManager
    {
        private ISotrudnikRepository _sotrudnikRepository;
        private IChildRepository _childRepository;

        public DataManager(ISotrudnikRepository sotrudnikRepository, IChildRepository childRepository)
        {
            _sotrudnikRepository = sotrudnikRepository;
            _childRepository = childRepository;
        }

        public SotrudnikRepository SotrudnikRepo { get { return (SotrudnikRepository) _sotrudnikRepository; } }

        public ChildRepository ChildRepo { get { return (ChildRepository) _childRepository; } }
    }
}
