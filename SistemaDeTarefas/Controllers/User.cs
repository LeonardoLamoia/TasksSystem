using Microsoft.AspNetCore.Mvc;

namespace SistemaDeTarefas.Controllers;

public class User : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}