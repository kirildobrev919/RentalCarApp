using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Contracts;
using RentalCar.Models.AppModels;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Mvc;

namespace RentalCar.Controllers
{
    //[Authorize]
    public class CarsController : Controller
    {
        IRepository<Car> repo;

        public CarsController(IRepository<Car> repo)
        {
            this.repo = repo;
        }

        [AllowAnonymous]
        // GET: Cars
        public ActionResult AllCars()
        {
            List<CarViewModel> viewModels = new List<CarViewModel>();
            var queryModels = repo.Read();
            foreach (var model in queryModels)
            {
                var viewModel = new CarViewModel()
                {
                    Id = model.Id,
                    Make = model.Make,
                    Model = model.Model,
                    Availability = model.Availability,
                    ReviewsCount = model.Reviews.Count()
                };
                viewModels.Add(viewModel);
            }
            return View(viewModels);
        }

        [AllowAnonymous]
        public ActionResult LoadReviews(int id)
        {
            List<CarReview> reviews = new List<CarReview>();
            var car = repo.Read(id);
            ViewBag.Id = car.Id;

            foreach (var item in car.Reviews)
            {
                reviews.Add(item);
            }

            return View(reviews);
        }

        [AllowAnonymous]
        // GET: Cars/Details/5
        public ActionResult Details(int id)
        {
            var queryModel = repo.Read(id);
            var viewModel = new CarViewModel()
            {
                Id = queryModel.Id,
                Make = queryModel.Make,
                Model = queryModel.Model,
                Availability = queryModel.Availability,
                ReviewsCount = queryModel.Reviews.Count()
            };
            return View(viewModel);
        }

        // GET: Cars/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        public ActionResult Create(ICar car)
        {
            var returned = 0;
            if (ModelState.IsValid)
            {
                returned = repo.Create((Car)car);
            }
            if (returned > 0) return RedirectToAction("AllCars");
            else return RedirectToAction("Create");
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {
            var car = repo.Read(id);
            if (car != null) return View(car);
            return NotFound();
        }

        // POST: Cars/Edit/5
        [HttpPost]
        public ActionResult Edit(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updated = repo.Update(car);
                    if (updated > 0)
                        return RedirectToAction("Details", new { id = car.Id });
                    else
                        return NotFound();
                }
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            var car = repo.Read(id);
            if (car != null) return View(car);
            return NotFound();
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Car car)
        {
            if (ModelState.IsValid)
            {
                var deleted = repo.DeleteConfirmed(car);
                if (deleted > 0) return RedirectToAction("AllCars");
                else return NotFound();
            }
            else return NotFound();
        }

        public ActionResult CustomError(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
