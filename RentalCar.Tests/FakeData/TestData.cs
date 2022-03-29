using RentalCar.Contracts;
using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalCar.Models.AppModels
{
    public static class TestData
    {
        public static IQueryable<Car> Cars
        {
            get
            {
                var cars = new List<Car>();

                var car = new Car
                {
                    Id = 1,
                    Make = "Ford",
                    Model = "Mustang",
                    Availability = true,
                    Reviews = new List<CarReview>() { new CarReview { Rating = 5, Review = "Very sporty" } }
                };
                cars.Add(car);

                car = new Car
                {
                    Id = 2,
                    Make = "Ford",
                    Model = "Mondeo",
                    Availability = true,
                    Reviews = new List<CarReview>() { new CarReview { Rating = 4, Review = "Very comfy" } }
                };
                cars.Add(car);

                car = new Car
                {
                    Id = 3,
                    Make = "Ford",
                    Model = "Ka",
                    Availability = true,
                    Reviews = new List<CarReview>() { new CarReview { Rating = 3, Review = "Smal but flexy" } }
                };
                cars.Add(car);

                return cars.AsQueryable();
            }
        }

        public static IQueryable<CarReview> Reviews
        {
            get
            {
                var revs = new List<CarReview>();

                var rev = new CarReview
                {
                    Id = 1,
                    CarId = 1,
                    Rating = 5,
                    Review = "Very sporty"
                };
                revs.Add(rev);

                rev = new CarReview
                {
                    Id = 2,
                    CarId = 2,
                    Rating = 4,
                    Review = "Very comfy"
                };
                revs.Add(rev);

                rev = new CarReview
                {
                    Id = 3,
                    CarId = 3,
                    Rating = 3,
                    Review = "Smal but flexy"
                };
                revs.Add(rev);

                return revs.AsQueryable();
            }
        }
    }
}