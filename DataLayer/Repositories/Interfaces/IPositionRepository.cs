﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        public Position GetPositionById(int positionId);

        public List<Position> GetAllPositions();
    }
}
