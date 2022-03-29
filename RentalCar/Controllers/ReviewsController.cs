using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Contracts;
using RentalCar.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace RentalCar.Controllers
{
    //[Authorize]
    public class ReviewsController : Controller
    {
        IRepository<CarReview> repo;

        public ReviewsController(IRepository<CarReview> repo)
        {
            this.repo = repo;
        }

        [AllowAnonymous]
        // GET: AllReviews
        public ActionResult AllReviews()
        {
            var queryModels = repo.Read().ToList();
            return View(queryModels);
        }

        [AllowAnonymous]
        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            var review = repo.Read(id);
            return View(review);
        }

        // GET: Reviews/AddReviews/5
        [HttpGet]
        public ActionResult AddReview(int id)
        { 
            ViewBag.CarId = id;
            return View();
        }

        // GET: Reviews/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(CarReview model)
        {
            int returned = 0;
            if (ModelState.IsValid)
            {
                returned = repo.Create(model);
            }
            if (returned > 0) return RedirectToAction("LoadReviews", "Cars", new { id = model.CarId });
            else return RedirectToAction("Create");
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            var review = repo.Read(id);
            if (review != null) return View(review);
            return NotFound();
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(CarReview model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updated = repo.Update(model);
                    if (updated > 0) return RedirectToAction("AllReviews");
                    else return NotFound();
                }
            }
            catch
            {
                return NotFound();
            }
            return NotFound();
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            var review = repo.Read(id);
            if (review != null) return View(review);
            return NotFound();
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(CarReview model)
        {
                var deleted = repo.DeleteConfirmed(model);
                if (deleted > 0) return RedirectToAction("AllReviews");
                else return NotFound();
        }
    }
}
