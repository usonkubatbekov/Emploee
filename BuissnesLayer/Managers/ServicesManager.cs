using PresentationLayer.Services;
using ServiceLayer.Managers.Interface;
using ServiceLayer.Services;
using ServiceLayer.Services.Interface;

namespace ServiceLayer.Managers
{
    public class ServicesManager : IServicesManager
    {
        private ISotrudnikService _sotrudnikService;
        private IChildService _childService;

        public ServicesManager(ISotrudnikService sotrudnikService, IChildService childService)
        {
            _sotrudnikService = sotrudnikService;
            _childService = childService;
        }

        public SotrudnikService SotrudnikService { get { return (SotrudnikService)_sotrudnikService; } }
        public ChildService ChildService { get { return (ChildService)_childService; } }
    }
}
