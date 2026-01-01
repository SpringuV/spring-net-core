using Microsoft.AspNetCore.Mvc;

namespace HttpContextExcercise.Controllers;

public class ResponseDemoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
}