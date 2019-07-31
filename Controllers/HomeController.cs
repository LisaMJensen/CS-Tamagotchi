using Microsoft.AspNetCore.Mvc;

namespace TamagotchiList.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

    }
}