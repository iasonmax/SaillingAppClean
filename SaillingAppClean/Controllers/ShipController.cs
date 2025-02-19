using Microsoft.AspNetCore.Mvc;
using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Domain.Entities;

namespace SaillingAppClean.Web.Controllers
{
    public class ShipController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ShipController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Ship> ships = _unitOfWork.Ship.GetAll().ToList();
            return View(ships);
        }

        public IActionResult Upsert(int? id)
        {
            if (id != null)
            {
                Ship? shipFromDb = _unitOfWork.Ship.Get(u => u.Id == id);
                if (shipFromDb == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(shipFromDb);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Upsert(Ship ship)
        {
            //todo fix if id not valid

            if (ModelState.IsValid)
            {
                if (ship.Id == 0)
                {
                    _unitOfWork.Ship.Add(ship);
                    TempData["success"] = "Ship added successfully";
                }
                else
                {
                    _unitOfWork.Ship.Update(ship);
                    TempData["success"] = "Ship added successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        #region API CALLS

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Ship.Get(u => u.Id == id);
            if (productToBeDeleted == null)
                return Json(new { success = false, message = "Error while deleting" });

            //var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath);

            //, productToBeDeleted.ImageUrl.TrimStart('\\')
            //if (System.IO.File.Exists(oldImagePath))
            //    System.IO.File.Delete(oldImagePath);

            _unitOfWork.Ship.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Ship deleted" });

        }
        #endregion
    }
}
