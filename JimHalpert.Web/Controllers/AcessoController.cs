using JimHalpert.App.ViewModel.Interface;
using JimHalpert.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JimHalpert.Web.Controllers
{
    [Route("[controller]")]
    public class AcessoController : Controller
    {
        private readonly IUsuarioServiceApp usuarioService;

        public AcessoController(IUsuarioServiceApp usuarioService)
        {
            this.usuarioService= usuarioService;
        }

        [HttpGet(""), AllowAnonymous]
        public IActionResult Index()
        {
            var model = new ModelLogin();
            return View(model);
        }
    }
}
