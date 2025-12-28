using System.Diagnostics;
using first_with_aspnet_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace first_with_aspnet_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository repository;

        public HomeController(IRepository repository,ILogger<HomeController> logger)
        {
            this.repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new HelloModel() { Name = "Spring Vu" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NewActionMethod(string name)
        {
            return Content("i am testing program New Action Method" + repository.GetById(name));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
