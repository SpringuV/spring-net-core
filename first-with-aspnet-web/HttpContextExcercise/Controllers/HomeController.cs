// HomeController.cs
// Summary: Controller for the sample app demonstrating usage of the custom session API.
// - Index stores a name in the session and commits it.
// - Privacy loads the session and reads the stored name to pass to the view.

using System.Diagnostics; // used for Activity in Error
using Microsoft.AspNetCore.Mvc; // MVC base classes and attributes
using HttpContextExcercise.Models; // ErrorViewModel type
using HttpContextExcercise.MySession; // custom session extension and interfaces

namespace HttpContextExcercise.Controllers;

public class HomeController : Controller
{
    // Logger instance injected via constructor
    private readonly ILogger<HomeController> _logger;

    // Constructor receives a logger from DI and stores it
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger; // assign injected logger to private field
    }

    // Index action: demonstrate writing to session and committing
    public async Task<IActionResult> Index()
    {
        // Log that Index was called (uses injected logger so it's considered used)
        _logger.LogInformation("Index action called");
        // Get or create the session from the current HttpContext using extension method
        var session = HttpContext.GetSession();
        // Store a short string value under key "Name"
        session.SetString("Name", "Spring Vu");
        // Persist session changes to the backing storage asynchronously
        await session.CommitAsync();
        
        // Return the default view for this action
        return View();
    }

    // Privacy action: demonstrate loading session data and reading a value
    public async Task<IActionResult> Privacy()
    {
        // Log that Privacy was called
        _logger.LogInformation("Privacy action called");
        // Get or create the session for this request
        var session = HttpContext.GetSession();
        // Load persisted data from storage into the session in case it hasn't been loaded
        await session.LoadAsync();
        // Retrieve the previously stored "Name" value (or null if not present)
        var name = session.GetString("Name");
        // Render the "Privacy" view and pass the name as the model
        return View("Privacy", name);
    }

    // Error action used by the framework when an error occurs
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // Create an ErrorViewModel with the current request id (useful for diagnostics)
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}