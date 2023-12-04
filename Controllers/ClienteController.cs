using Microsoft.AspNetCore.Mvc;

namespace Mvcapprest.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}