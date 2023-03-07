using DataLayer.Entities;

namespace ServiceLayer.Dtos
{
    public class EmployeeDto : PersonDto
    {
        public string? Position { get; set; }
        public List<Positiondto> Positions { get; set; }
        public List<Child> Childrens { get; set; } = new List<Child>();
    }
}
