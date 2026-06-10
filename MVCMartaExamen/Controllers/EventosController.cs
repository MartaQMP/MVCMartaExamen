using MVCMartaExamen.Models;
using Microsoft.AspNetCore.Mvc;
using MVCMartaExamen.Services;

namespace MVCMartaExamen.Controllers
{
    public class EventosController : Controller
    {
        private ServiceApiGateway service;
        private string urlBucket;

        public EventosController(ServiceApiGateway service, IConfiguration configuration)
        {
            this.service = service;
            this.urlBucket = configuration.GetValue<string>("AWS:BucketName");
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            ViewBag.UrlBucket = this.urlBucket;
            return View(eventos);
        }

        [HttpGet]
        public async Task<IActionResult> Buscador()
        {
            List<Categoria> categorias = await this.service.GetCategoriasAsync();
            ViewData["CATEGORIAS"] = categorias;
            ViewBag.UrlBucket = this.urlBucket;
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Buscador(int idCategoria)
        {
            List<Categoria> categorias = await this.service.GetCategoriasAsync();
            ViewData["CATEGORIAS"] = categorias;
            ViewData["ID_SELECCIONADO"] = idCategoria;
            List<Evento> eventos = await this.service.GetEventosCategoriaAsync(idCategoria);
            ViewBag.UrlBucket = this.urlBucket;
            return View(eventos);
        }
    }
}
