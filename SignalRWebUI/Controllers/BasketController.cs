using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
