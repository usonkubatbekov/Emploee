using ServiceLayer.Dtos;

namespace ServiceLayer.Services.Interface
{
    public interface IChildService
    {
        ChildDto GetChildById(int employee);
        List<ChildDtoForIndex> GetAllChilds();
        ChildDto SaveChild(ChildDto dto);
        ChildDto UpdateChild(ChildDto dto);
        ChildDto DeleteChildById(ChildDto dto);
    }
}
