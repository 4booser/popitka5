using Microsoft.AspNetCore.Mvc;

public class TestController : Controller
{
    public IActionResult Index()
    {
        string name = "Lesha";
        return View("Index", name);
    }
}


