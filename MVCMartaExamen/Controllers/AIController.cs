using Microsoft.AspNetCore.Mvc;
using MVCMartaExamen.Services;

namespace MVCMartaExamen.Controllers
{
    public class AIController : Controller
    {
        private readonly ServiceIA service;

        public AIController(ServiceIA service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string question)
        {
            var answer = await this.service.AskAsync(question);

            ViewData["answer"] = answer;

            return View();
        }
    }
}
