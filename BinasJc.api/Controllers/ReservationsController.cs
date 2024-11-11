using Microsoft.AspNetCore.Mvc;

namespace BinasJc.api.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
