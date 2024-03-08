using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
