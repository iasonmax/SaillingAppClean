using Microsoft.AspNetCore.Mvc;
using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Domain.Entities;

namespace SaillingAppClean.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Ship> ships = _unitOfWork.Ship.GetAll(includeProperties: "Category").ToList();
            return View(ships);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
