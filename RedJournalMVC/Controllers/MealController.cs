using Microsoft.AspNet.Identity;
using RedJournal.Models.Meal;
using RedJournal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedJournalMVC.Controllers
{
    [Authorize]
    public class MealController : Controller
    {
        // GET: Meal
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);
            var model = service.GetMeals();
            return View(model);
        }

        //GET:  Create Meal
        public ActionResult Create()
        {
            return View(new MealCreate());
        }

        //POST:  Create Meal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMealService();

            if (service.CreateMeal(model))
            {
                TempData["SaveResult"] = "Your meal was successfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Meal could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMealService();
            var detail = service.GetMealById(id);
            var model = new MealEdit
            {
                MealId = detail.MealId,
                Name = detail.Name,
                MoodBefore = detail.MoodBefore,
                MoodAfter = detail.MoodAfter,
                HungerBefore = detail.HungerBefore,
                HungerAfter = detail.HungerAfter,
                Location = detail.Location,
                WhoWith = detail.WhoWith,
                Notes = detail.Notes
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.MealId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMealService();

            if (service.UpdateMeal(model))
            {
                TempData["SaveResult"] = "Your meal was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your meal could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMealService();
            service.DeleteMeal(id);
            TempData["SaveResult"] = "Your Meal has been successfully deleted";
            return RedirectToAction("Index");
        }

        private MealService CreateMealService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);
            return service;
        }
    }
}