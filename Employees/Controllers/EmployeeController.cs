using Employees.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dtos;
using ServiceLayer.Managers.Interface;

namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IServicesManager _servicesManager;

        public EmployeeController(IServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
        }
        public IActionResult Index()
        {
            var vm = new EmployerViewModel()
            {
                Employer = _servicesManager.EmployeeService.GetEmployeeById(123),
                EmployerDtoForIndex = _servicesManager.EmployeeService.GetAllEmployees()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _servicesManager.EmployeeService.GetEmployeeById(id);
            if (employee == null) 
                return NotFound("Not Found");
            else
                return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                _servicesManager.EmployeeService.UpdateEmployee(employeeDto);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Edit", "Employee", employeeDto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                _servicesManager.EmployeeService.SaveEmployee(dto);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var vm = new EmployerViewModel()
            {
                Employer = _servicesManager.EmployeeService.GetEmployeeById(id)
            };

            return View(vm);
        }


        public IActionResult Delete(int Id)
        {
            var vm = new EmployerViewModel()
            {
                Employer = _servicesManager.EmployeeService.GetEmployeeById(Id)
            };

            if (vm.Employer == null) 
                return NotFound("Сотрудник не найден");
            else
            return View(vm);
        }

        [HttpPost,ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            var vm = new EmployerViewModel()
            {
                Employer = _servicesManager.EmployeeService.GetEmployeeById(id)
            };
            if (vm.Employer == null) 
            { 
                return NotFound(); 
            }
            else
            _servicesManager.EmployeeService.DeleteEmployeeById(vm.Employer);
            return RedirectToAction(nameof(Index));
        }

    }
}
