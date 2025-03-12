using Microsoft.AspNetCore.Mvc;
using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Application.Common.Utility;
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
            var bookings = _unitOfWork.Booking.GetAll(u => u.Status == SD.Status_Approved || u.Status == SD.Status_CheckedIn, includeProperties: "Ship").ToList();
            foreach (var ship in shipList)
            {
                ship.IsAvailiable = SD.ShipsAvailiability(ship.Id, embarkingDate, disembarkingDate, bookings);
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
