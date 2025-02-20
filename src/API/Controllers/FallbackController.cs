using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dama.Fin.API.Controllers;

public class FallbackController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        //return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"),"text/HTML");
        return View();
    }
}