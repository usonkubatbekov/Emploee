using System.Diagnostics;
using Employees.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Managers.Interface;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        private IServicesManager _servicesManager;
        private IDataManager _dataManager;

        public HomeController(IServicesManager servicesManager, IDataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = servicesManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}