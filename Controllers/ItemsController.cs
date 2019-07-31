using Microsoft.AspNetCore.Mvc;
using TamagotchiList.Models;
using System.Collections.Generic;

namespace TamagotchiList.Controllers
{
    public class TamagotchiController : Controller
    {

        [HttpGet("/tamagotchi")]
        public ActionResult Index()
        {
            List<Tamagotchi> allTamagotchi = Tamagotchi.GetAll();
            return View(allTamagotchi);
        }

        [HttpGet("/tamagotchi/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/tamagotchi")]
        public ActionResult Create(string description)
        {
            Tamagotchi myTamagotchi = new Tamagotchi(description);
            return RedirectToAction("Index");
        }

        [HttpPost("/tamagotchi/delete")]
        public ActionResult DeleteAll()
        {
            Tamagotchi.ClearAll();
            return View();
        }

        [HttpGet("/tamagotchi/{id}")]
        public ActionResult Show(int id)
        {
            Tamagotchi foundTamagotchi = Tamagotchi.Find(id);
            return View(foundTamagotchi);
        }

    }
}