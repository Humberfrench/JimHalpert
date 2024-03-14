using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    [Route("[controller]")]
    public class ServicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
