using AutoMapper;
using ServiceLayer.Dtos;
using ServiceLayer.Managers.Interface;
using ServiceLayer.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class PositionService : IPositionService
    {
        private readonly IDataManager _dataManager;
        private readonly IMapper _mapper;

        public PositionService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }
        public List<Positiondto> GetPositionList()
        {
            return _mapper.Map<List<Positiondto>>(_dataManager.PositionRepo.GetAllPositions());
        }
    }
}
