using Microsoft.AspNetCore.Mvc;
using SailingAppClean.Application.Common.Interfaces;
using SailingAppClean.Domain.Entities;

namespace SaillingAppClean.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> ships = _unitOfWork.Category.GetAll().ToList();
            return View(ships);
        }

        public IActionResult Upsert(int? id)
        {
            if (id != null)
            {
                Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
                if (categoryFromDb == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                return View(categoryFromDb);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Upsert(Category category)
        {
            //todo fix if id not valid

            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                    TempData["success"] = "Category added successfully";
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                    TempData["success"] = "Category added successfully";
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
            var productToBeDeleted = _unitOfWork.Category.Get(u => u.Id == id);
            if (productToBeDeleted == null)
                return Json(new { success = false, message = "Error while deleting" });

            //var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath);

            //, productToBeDeleted.ImageUrl.TrimStart('\\')
            //if (System.IO.File.Exists(oldImagePath))
            //    System.IO.File.Delete(oldImagePath);

            _unitOfWork.Category.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Category deleted" });

        }
        #endregion
    }
}
