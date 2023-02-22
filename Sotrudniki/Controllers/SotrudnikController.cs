using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Models;
using ServiceLayer.Managers.Interface;

namespace Sotrudniki.Controllers
{
    public class SotrudnikController : Controller
    {
        private IServicesManager _servicesManager;
        private IDataManager _dataManager;

        public SotrudnikController(IServicesManager servicesManager, IDataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = servicesManager;
        }
        public IActionResult Index()
        {
            var vm = new SotrudnikViewModel()
            {
                Sotrudnik = _servicesManager.SotrudnikService.GetSotrudnikById(123),
                sotrudnikDtoforIndices = _servicesManager.SotrudnikService.GetAllSotrudniks()
            };

            return View(vm);
        }

        [HttpPost]

        public IActionResult SaveSotrudnik(SotrudnikDto dto)
        {
            _servicesManager.SotrudnikService.SaveSotrudnik(dto);
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sotrudnik = _servicesManager.SotrudnikService.GetSotrudnikById(id);
            return View(sotrudnik);
        }

        [HttpPost]
        public IActionResult Edit(SotrudnikDto sotrudnikDto)
        {
            if (ModelState.IsValid)
            {
                _servicesManager.SotrudnikService.UpdateSotrudnik(sotrudnikDto);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Edit", "Sotrudnik", sotrudnikDto);
        }


        [HttpPost]
        public IActionResult Create(SotrudnikDto dto)
        {
            _servicesManager.SotrudnikService.SaveSotrudnik(dto);
            return RedirectToAction("Index");
        }


        public IActionResult Details(SotrudnikDto sotrudnikDto)
        {

            var vm = new SotrudnikViewModel()
            {
                Sotrudnik = _servicesManager.SotrudnikService.GetSotrudnikById(sotrudnikDto.Id)
            };

            return View(vm);
        }


        public IActionResult Delete(SotrudnikDto sotrudnikDto)
        {
            if (sotrudnikDto.Id == null)
            {
                return NotFound();
            }
            var vm = new SotrudnikViewModel()
            {
                Sotrudnik = _servicesManager.SotrudnikService.GetSotrudnikById(sotrudnikDto.Id)
            };
            return View(vm);
        }

        [HttpPost,ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(SotrudnikViewModel dto)
        {
            var id = dto.Sotrudnik.Id;
            var vm = new SotrudnikViewModel()
            {
                Sotrudnik = _servicesManager.SotrudnikService.GetSotrudnikById(id)
            };
            
            _servicesManager.SotrudnikService.DeleteSotrudnikById(vm.Sotrudnik);
            return RedirectToAction(nameof(Index));
        }

    }
}
