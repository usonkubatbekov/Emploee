using Employees.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dtos;
using ServiceLayer.Managers.Interface;

namespace Employees.Controllers
{
    public class ChildController : Controller
    {
        private readonly IServicesManager _servicesManager;

        public ChildController(IServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
        }

        public IActionResult Index([FromRoute] int id)
        {
            var vm = new ChildViewModel()
            {
                EmployeeId = id,
                Childs = _servicesManager.ChildService.GetChildListByEmployeeId(id),
                ChildsforIndex = _servicesManager.ChildService.GetAllChilds()
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {

            var vm = new ChildViewModel()
            {
                Child = _servicesManager.ChildService.GetChildById(id)
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            return View(new ChildDto()
            {
                EmployeeId = id
            });
        }

        [HttpPost]
        public IActionResult Create(ChildDto dto)
        {
            if (ModelState.IsValid)
            {
                _servicesManager.ChildService.SaveChild(dto);
                return RedirectToAction(nameof(Index), new { id = dto.EmployeeId });
            }
            return RedirectToAction(nameof(Create), dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var child = _servicesManager.ChildService.GetChildById(id);
            return View(child);
        }

        [HttpPost]
        public IActionResult Edit(ChildDto dto)
        {
            _servicesManager.ChildService.UpdateChild(dto);
            return RedirectToAction("Index", "Child", new { id = dto.EmployeeId });
        }

        public IActionResult Delete(int id)
        {
            var vm = new ChildViewModel()
            {
                Child = _servicesManager.ChildService.GetChildById(id)
            };
            if (vm.Child == null) 
            {
                return NotFound();
            }
            else
            return View(vm);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var vm = new ChildViewModel()
            {
               Child  = _servicesManager.ChildService.GetChildById(id)
            };
            if (vm.Child == null)
            {
                return NotFound();
            }
            else
            _servicesManager.ChildService.DeleteChildById(vm.Child);
            return RedirectToAction(nameof(Index), new { id = vm.Child.EmployeeId });
        }
    }
}
