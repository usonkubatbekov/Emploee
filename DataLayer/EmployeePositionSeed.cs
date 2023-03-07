using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal static class EmployeePositionSeed
    {
        internal static ModelBuilder AddPositionSeed(this ModelBuilder builder)
        {
            var positionlist = new List<Position>()
            {
                new Position()
                {
                   Id = 1,
                    Name="Директор"
                },
                new Position()
                {
                    Id = 2,
                   Name="Заместитель директора"
                },
                new Position()
                {
                    Id = 3,
                   Name="Начальник"
                },
                new Position()
                {
                    Id = 4,
                   Name="Главный специалист"
                },
                new Position()
                {
                    Id = 5,
                   Name="Ведущий специалист"
                },
                new Position()
                {
                    Id = 6,
                   Name="Специалист"
                }

            };

            builder.Entity<Position>().HasData(positionlist);
            return builder;
        }
    }
}
