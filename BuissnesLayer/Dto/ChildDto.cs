using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class ChildDto
    {
        public int Id { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public int SotrudnikId { get; set; }

        public SotrudnikEntity Sotrudnik { get; set; }
    }
}
