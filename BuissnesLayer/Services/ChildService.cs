using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Entityes;
using PresentationLayer.Models;
using ServiceLayer.Dto;
using ServiceLayer.Managers.Interface;
using ServiceLayer.Services.Interface;

namespace PresentationLayer.Services
{
    public class ChildService : IChildService
    {
        private readonly IDataManager _dataManager;
        private readonly IMapper _mapper;

        public ChildService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public List<ChildDtoForIndex> GetAllChilds()
        {
            return _mapper.Map<List<ChildDtoForIndex>>(_dataManager.ChildRepo.GetAllChilds());
        }

        public ChildDto GetChildById(int sotrudnikId)
        {
            return _mapper.Map<ChildDto>(_dataManager.ChildRepo.GetChildById(sotrudnikId));
        }

        public List<ChildDto> GetChildListBySotrudnikId(int sotrudnikId)
        {
            return _mapper.Map<List<ChildDto>>(_dataManager.ChildRepo.GetChildBySotrudnikId(sotrudnikId));
        }

        public ChildDto SaveChild(ChildDto dto)
        {
            ChildEntity child = new ChildEntity();

            child.SurName = dto.SurName;
            child.Name = dto.Name;
            child.LastName = dto.LastName;
            child.BirthDay = dto.BirthDay;
            child.SotrudnikId = dto.SotrudnikId;
            
            var createdchild = _dataManager.ChildRepo.CreateChild(child);

            return _mapper.Map<ChildDto>(createdchild);
        }

        public ChildDto UpdateChild(ChildDto dto)
        {
            ChildEntity child;

            child = _mapper.Map<ChildEntity>(dto);

            var id = _dataManager.ChildRepo.UpdateChild(child);

            return dto;
        }

        public ChildDto DeleteChildById(ChildDto dto)
        {
            ChildEntity child;

            child = _mapper.Map<ChildEntity>(dto);

            _dataManager.ChildRepo.DeleteChild(child);

            return dto;
        }
    }
}
