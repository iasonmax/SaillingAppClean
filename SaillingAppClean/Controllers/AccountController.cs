using Microsoft.AspNetCore.Mvc;

namespace SaillingAppClean.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
