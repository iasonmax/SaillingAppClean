using Microsoft.AspNetCore.Mvc;
using SailingAppClean.Domain.Entities;
using SaillingAppClean.Infrastructure.Data;

namespace SaillingAppClean.Web.Controllers
{
    public class ShipController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ShipController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Ship> ships = _db.Ships.ToList();
            return View(ships);
        }

        public IActionResult Upsert(int? id)
        {
            if (id != null)
            {
                Ship? shipFromDb = _db.Ships.FirstOrDefault(u => u.Id == id);
                return View(shipFromDb);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Upsert(Ship ship)
        {
            if (ModelState.IsValid)
            {
                if (ship.Id == 0)
                {
                    _db.Ships.Add(ship);
                }
                else
                {
                    _db.Ships.Update(ship);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
