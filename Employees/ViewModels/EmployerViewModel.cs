using ServiceLayer.Dtos;

namespace Employees.ViewModels
{
    public class EmployerViewModel
    {
        public List<EmployeeDto>? Employees { get; set; }

        public List<EmloyeeDtoforIndex>? EmployerDtoForIndex { get; set; }

        public EmployeeDto? Employer { get; set; }

    }
}
