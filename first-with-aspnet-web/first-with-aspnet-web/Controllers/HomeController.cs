using System.Diagnostics;
using first_with_aspnet_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace first_with_aspnet_web.Controllers
{
    //[NonController] // controller will not be treated as controller
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

        //[NonAction] // seem like not action method, it will not be callable from browser
        public ActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("/api/users")]
        public IActionResult Users([FromHeader] string apiKey, [FromServices] IUserRepository userRepository)
        {
            _logger.LogInformation("[USERS] Method: {m}, ApiKey: {k}", Request.Method, apiKey);
            ValidateApiKey(apiKey);
            return Content("Users with ApiKey: " + apiKey +$"\nUserRepo: {string.Join(",\n", userRepository.GetUsers)}");
        }

        private void ValidateApiKey(string apiKey)
        {
            if (apiKey == null)
            {
                throw new NotImplementedException();
            }
        }

        [HttpPost]
        [Route("/api/users")]
        public IActionResult Users([FromHeader] string apiKey, [FromServices] IUserRepository userRepository, [FromForm]string userNew)
        {
            _logger.LogInformation("[USERS] Method: {m}, ApiKey: {k}", Request.Method, apiKey);
            ValidateApiKey(apiKey);
            userRepository.Add(userNew);
            return Ok("Added user: " + userNew);
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
