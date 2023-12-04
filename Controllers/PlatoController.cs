using Microsoft.AspNetCore.Mvc;

namespace Mvcapprest.Controllers
{
    public class PlatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}