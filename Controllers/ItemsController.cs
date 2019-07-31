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
        public ActionResult Create(string description, int foodLevel, int attentionLevel, int sleepLevel)
        {
            Tamagotchi myTamagotchi = new Tamagotchi(description, foodLevel, attentionLevel, sleepLevel);
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

        [HttpPost("/tamagotchi/feed/{id}")]
        public ActionResult ChangeFood(int id)
        {
            List<Tamagotchi> listTamagotchi = Tamagotchi.GetAll();
            foreach (Tamagotchi tamagotchi in listTamagotchi)
            {
                tamagotchi.FoodLevel -= 1;
                tamagotchi.AttentionLevel -= 1;
                tamagotchi.SleepLevel -= 1;
            }
            Tamagotchi foundTamagotchi = Tamagotchi.Find(id);
            foundTamagotchi.FoodLevel += 6;
            return View("Show", foundTamagotchi);
        }


        [HttpPost("/tamagotchi/pet/{id}")]
        public ActionResult ChangeHappy(int id)
        {


            List<Tamagotchi> listTamagotchi = Tamagotchi.GetAll();
            foreach (Tamagotchi tamagotchi in listTamagotchi)
            {
                tamagotchi.FoodLevel -= 1;
                tamagotchi.AttentionLevel -= 1;
                tamagotchi.SleepLevel -= 1;
            }

            Tamagotchi foundTamagotchi = Tamagotchi.Find(id);
            foundTamagotchi.AttentionLevel += 6;
            return View("Show", foundTamagotchi);
        }
        [HttpPost("/tamagotchi/tranq/{id}")]
        public ActionResult ChangeEnergy(int id)
        {
            List<Tamagotchi> listTamagotchi = Tamagotchi.GetAll();
            foreach (Tamagotchi tamagotchi in listTamagotchi)
            {
                tamagotchi.FoodLevel -= 1;
                tamagotchi.AttentionLevel -= 1;
                tamagotchi.SleepLevel -= 1;
            }
            Tamagotchi foundTamagotchi = Tamagotchi.Find(id);
            foundTamagotchi.SleepLevel += 6;
            return View("Show", foundTamagotchi);
        }

        //     [HttpPost("/tamagotchi/pet")]
        //     public ActionResult do something that pets 1, and subtracts from all others
        //         {

        //         }

        // [HttpPost("/tamagotchi/tranq")]
        // ActionResult do something that tranqs 1, and subtracts from all others
        //         {

        //         }



    }
}