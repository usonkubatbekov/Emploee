using PresentationLayer.Models;
using ServiceLayer.Dto;

namespace ServiceLayer.Services.Interface
{
    public interface IChildService
    {
        ChildDto GetChildById(int sotrudnikId);
        List<ChildDtoForIndex> GetAllChilds();
        ChildDto SaveChild(ChildDto dto);
        ChildDto UpdateChild(ChildDto dto);
        ChildDto DeleteChildById(ChildDto dto);
    }
}
