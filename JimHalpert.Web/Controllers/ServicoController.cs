using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    public class ServicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
