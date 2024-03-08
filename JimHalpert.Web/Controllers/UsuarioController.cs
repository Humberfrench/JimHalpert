using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
