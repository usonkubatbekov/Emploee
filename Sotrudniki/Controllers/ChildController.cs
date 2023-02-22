using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using ServiceLayer.Managers.Interface;

namespace Sotrudniki.Controllers
{
    public class ChildController : Controller
    {
        private IServicesManager _servicesManager;
        private IDataManager _dataManager;

        public ChildController(IServicesManager servicesManager, IDataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = servicesManager;
        }

        public IActionResult Index([FromRoute] int id)
        {
            var vm = new ChildViewModel()
            {
                SotrudnikId = id,
                Childs = _servicesManager.ChildService.GetChildListBySotrudnikId(id),
                ChildforIndex = _servicesManager.ChildService.GetAllChilds()
            };

            return View(vm);
        }


        public IActionResult Details(ChildDto childDto)
        {

            var vm = new ChildViewModel()
            {
                Child = _servicesManager.ChildService.GetChildById(childDto.Id)
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            return View(new ChildDto()
            {
                SotrudnikId = id
            });
        }

        [HttpPost]
        public IActionResult Create(ChildDto dto)
        {
            _servicesManager.ChildService.SaveChild(dto);
            return RedirectToAction(nameof(Index), new { id = dto.SotrudnikId });
        }


        [HttpPost]
        public IActionResult SaveChild(ChildDto dto)
        {
            _servicesManager.ChildService.SaveChild(dto);
            return View();
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
            var child = _servicesManager.ChildService.GetChildById(dto.Id);
            _servicesManager.ChildService.UpdateChild(dto);
            return RedirectToAction("Index", "Child", new { id = dto.SotrudnikId });
        }

        public IActionResult Delete(ChildDto childDto)
        {
            if (childDto.Id == null)
            {
                return NotFound();
            }
            var vm = new ChildViewModel()
            {
                Child = _servicesManager.ChildService.GetChildById(childDto.Id)
            };
            return View(vm);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(ChildViewModel dto)
        {
            var id = dto.Child.Id;
            var vm = new ChildViewModel()
            {
               Child  = _servicesManager.ChildService.GetChildById(id)
            };

            _servicesManager.ChildService.DeleteChildById(vm.Child);
            return RedirectToAction(nameof(Index));
        }

    }
}
