using PresentationLayer.Services;
using ServiceLayer.Services;

namespace ServiceLayer.Managers.Interface
{
    public interface IServicesManager
    {
        SotrudnikService SotrudnikService { get; }
        ChildService ChildService { get; }
    }
}
