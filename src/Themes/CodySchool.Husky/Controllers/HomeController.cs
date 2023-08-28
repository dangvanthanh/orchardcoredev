using Microsoft.AspNetCore.Mvc;

namespace CodySchool.Husky.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}