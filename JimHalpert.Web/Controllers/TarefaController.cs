using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    public class TarefaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
