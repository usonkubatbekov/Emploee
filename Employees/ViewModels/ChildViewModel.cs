using ServiceLayer.Dtos;

namespace Employees.ViewModels
{
    public class ChildViewModel
    {
        public List<ChildDto> Childs { get; set; }

        public List<ChildDtoForIndex> ChildsforIndex { get; set; }

        public ChildDto Child { get; set; }

        public int EmployeeId { get; set; }
    }
}
