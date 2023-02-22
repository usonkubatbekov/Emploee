using AutoMapper;
using DataLayer.Entityes;
using PresentationLayer.Models;
using ServiceLayer.Dto;
using ServiceLayer.Managers.Interface;
using ServiceLayer.Services.Interface;

namespace ServiceLayer.Services
{
    public class SotrudnikService : ISotrudnikService
    {
        private readonly IDataManager _dataManager;
        private readonly IMapper _mapper;

        public SotrudnikService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        
         public SotrudnikDto GetSotrudnikById(int sotrudnikId)
         {
             return _mapper.Map<SotrudnikDto>(_dataManager.SotrudnikRepo.GetSotrudnikById(sotrudnikId));           
         }

         public List<SotrudnikDtoforIndex> GetAllSotrudniks()
         {
             return _mapper.Map<List<SotrudnikDtoforIndex>>(_dataManager.SotrudnikRepo.GetAllSotrudniks());
         }

         public SotrudnikDto SaveSotrudnik(SotrudnikDto dto)
         {
             SotrudnikEntity sotrudnik;

             if (dto.Id != 0) 
             {
                 sotrudnik = _dataManager.SotrudnikRepo.GetSotrudnikById(dto.Id);
             }
             else 
             {
                 sotrudnik = new SotrudnikEntity();
             }

             sotrudnik.SurName = dto.SurName;
             sotrudnik.Name = dto.Name;
             sotrudnik.LastName = dto.LastName;
             sotrudnik.BirthDay = dto.BirthDay;
             sotrudnik.Position = dto.Position;  

             var id = _dataManager.SotrudnikRepo.CreateSotrudnik(sotrudnik);

             return _mapper.Map<SotrudnikDto>(sotrudnik);
         }

         public SotrudnikDto UpdateSotrudnik(SotrudnikDto dto) 
         {
            SotrudnikEntity Sotrudnik;

            Sotrudnik = _mapper.Map<SotrudnikEntity>(dto);

            var id =_dataManager.SotrudnikRepo.UpdateSotrudnik(Sotrudnik);
            
            return dto;
         }

        public SotrudnikDto DeleteSotrudnikById(SotrudnikDto dto)
        {
            SotrudnikEntity sotrudnik;

            sotrudnik = _mapper.Map<SotrudnikEntity>(dto);

            _dataManager.SotrudnikRepo.DeleteSotrudnik(sotrudnik);

            return dto;
        }

    }
}
