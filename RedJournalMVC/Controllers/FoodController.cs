using Microsoft.AspNet.Identity;
using RedJournal.Models.Food;
using RedJournal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedJournalMVC.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            var model = service.GetFoods();
            return View(model);
        }

        //GET: Create Food
        public ActionResult Create()
        {
            return View(new FoodCreate());
        }

        //POST:  Create Food
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodCreate model)
        {
            if (!ModelState.IsValid) return View(model);

               var service = CreateFoodService();

               if (service.CreateFood(model))
               {
                    TempData["SaveResult"] = "Your Food was successfully created.";
                    return RedirectToAction("Index");
               };

            ModelState.AddModelError("", "Food could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFoodService();
            var model = svc.GetFoodById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFoodService();
            var detail = service.GetFoodById(id);
            var model = new FoodEdit
            {
                FoodId = detail.FoodId,
                Name = detail.Name,
                Amount = detail.Amount,
                Calories = detail.Calories
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.FoodId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodService();

            if (service.UpdateFood(model))
            {
                TempData["SaveResult"] = "Your food was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your food could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateFoodService();
            var model = svc.GetFoodById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFoodService();
            service.DeleteFood(id);
            TempData["SaveResult"] = "Your Food has been deleted.";
            return RedirectToAction("Index"); 
        }

        private FoodService CreateFoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            return service;
        }
    }
}