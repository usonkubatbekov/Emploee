using PresentationLayer.Models;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class ChildViewModel
    {
        public List<ChildDto> Childs { get; set; }

        public List<ChildDtoForIndex> ChildforIndex { get; set; }

        public ChildDto Child { get; set; }

        public int SotrudnikId { get; set; }
    }
}
