using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    [Route("[controller]")]
    public class TarefaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
