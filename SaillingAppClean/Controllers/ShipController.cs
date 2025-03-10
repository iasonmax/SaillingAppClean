using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Application.Common.Utility;
using SailingAppClean.Domain.Entities;
using SaillingAppClean.Web.ViewModels;

namespace SaillingAppClean.Web.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
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
            IEnumerable<Ship> ships = _unitOfWork.Ship.GetAll(includeProperties: "Category").ToList();
            return View(ships);
        }

        public IActionResult Upsert(int? id)
        {
            // Initialize the ViewModel
            ShipVm shipVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),
                Ship = new Ship()
            };
            if (id == null)
            {
                return View(shipVM);
            }
            // If id is not null, fetch the ship from the database
            if (id != null)
            {
                Ship? shipFromDb = _unitOfWork.Ship.Get(u => u.Id == id);
                if (shipFromDb == null)
                {
                    // Redirect to an error page if the ship is not found
                    return RedirectToAction("Error", "Home");
                }

                // Populate the Ship property of the ViewModel with the fetched data
                shipVM.Ship = shipFromDb;
                return View(shipVM);
            }

            // if you get here you messed up
            return View();
        }

        [HttpPost]
        public IActionResult Upsert(Ship ship)
        {
            //todo fix if id not valid

            if (ModelState.IsValid)
            {
                if (ship.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ship.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images/Ships");

                    if (ship.Id > 0)
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, ship.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    ship.Image.CopyTo(fileStream);

                    ship.ImageUrl = @"\images\Ships\" + fileName;
                }

                if (ship.Id == 0)
                {
                    _unitOfWork.Ship.Add(ship);
                    TempData["success"] = "Ship added successfully";
                }
                else
                {
                    _unitOfWork.Ship.Update(ship);
                    TempData["success"] = "Ship updated successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Ship> ships = _unitOfWork.Ship.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = ships });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Ship.Get(u => u.Id == id);
            if (productToBeDeleted == null)
                return Json(new { success = false, message = "Error while deleting" });

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, _unitOfWork.Ship.Get(u => u.Id == id).ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Ship.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Ship deleted" });

        }
        #endregion
    }
}
