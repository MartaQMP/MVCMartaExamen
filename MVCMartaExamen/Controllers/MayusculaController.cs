using Microsoft.AspNetCore.Mvc;
using MVCMartaExamen.Services;

namespace MVCMartaExamen.Controllers
{
    public class MayusculaController : Controller
    {
        private readonly ServiceMayusculas service;

        public MayusculaController(ServiceMayusculas service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string texto)
        {
            var resultado = await this.service.ConvertirMayusculasAsync(texto);
            ViewData["resultado"] = resultado;
            return View();
        }
    }
}
