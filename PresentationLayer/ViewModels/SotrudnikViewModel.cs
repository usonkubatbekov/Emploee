using DataLayer.Entityes;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class SotrudnikViewModel
    {
        public List<SotrudnikDto> Sotrudniks { get; set; }

        public List<SotrudnikDtoforIndex> sotrudnikDtoforIndices { get; set; }

        public SotrudnikDto Sotrudnik { get; set; }

    }
}
