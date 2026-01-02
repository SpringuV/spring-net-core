// ResponseDemoController.cs
// Summary: Minimal controller to show a response view for demo purposes.

using Microsoft.AspNetCore.Mvc; // MVC types

namespace HttpContextExcercise.Controllers;

public class ResponseDemoController : Controller
{
    // Index action returns the default view for this controller
    public IActionResult Index()
    {
        return View(); // render the view located at Views/ResponseDemo/Index.cshtml
    }
    
}