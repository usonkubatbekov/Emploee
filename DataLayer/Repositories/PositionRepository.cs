using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly EmployeeEFDBcontext _dbcontext;

        public PositionRepository(EmployeeEFDBcontext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public List<Position> GetAllPositions()
        {
            return _dbcontext.Positions.ToList();
        }

        public Position GetPositionById(int positionId)
        {
            return _dbcontext.Positions!.AsNoTracking<Position>().FirstOrDefault(x => x.Id == positionId);
        }

    }
}
