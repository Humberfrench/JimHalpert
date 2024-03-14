using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
