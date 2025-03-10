using Microsoft.AspNetCore.Mvc;
using SailingAppClean.Application.Common.Interfaces;
using SaillingAppClean.Web.ViewModels;

namespace SaillingAppClean.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                ShipList = _unitOfWork.Ship.GetAll(includeProperties: "Category"),
                EmbarkationDate = DateOnly.FromDateTime(DateTime.Now),
                DisembarkationDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
            };
            return View(homeVM);
        }


        [HttpPost]
        public IActionResult GetShipsByDate(DateOnly embarkingDate, DateOnly disembarkingDate)
        {
            Thread.Sleep(2000);
            var shipList = _unitOfWork.Ship.GetAll(includeProperties: "Category");
            foreach (var ship in shipList)
            {
                if (ship.Id % 2 == 0)
                {
                    ship.IsAvailiable = false;
                }
            }
            HomeVM homeVM = new()
            {
                ShipList = shipList,
                EmbarkationDate = embarkingDate,
                DisembarkationDate = disembarkingDate
            };
            return PartialView("_ShipList", homeVM);
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
