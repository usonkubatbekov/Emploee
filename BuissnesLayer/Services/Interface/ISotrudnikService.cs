using PresentationLayer.Models;
using ServiceLayer.Dto;

namespace ServiceLayer.Services.Interface
{
    public interface ISotrudnikService
    {
        SotrudnikDto GetSotrudnikById(int sotrudnikId);
        List<SotrudnikDtoforIndex> GetAllSotrudniks();
        SotrudnikDto SaveSotrudnik(SotrudnikDto dto);
        SotrudnikDto UpdateSotrudnik(SotrudnikDto dto);
        SotrudnikDto DeleteSotrudnikById(SotrudnikDto dto);
    }
}
