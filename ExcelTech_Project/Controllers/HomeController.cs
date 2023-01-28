using Microsoft.AspNetCore.Mvc;

namespace ExcelTech_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
