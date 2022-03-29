using RentalCar.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalCar.Models.AppModels
{
    public class ReviewRepository : IRepository<CarReview>
    {
        public RentalCarDb Db { get; set; }

        public ReviewRepository()
        {
            Db = new RentalCarDb();
        }

        public ICollection<CarReview> Read()
        {
            var cars = Db.CarReviews;
            return cars.ToList<CarReview>();
        }

        public CarReview Read(int id)
        {
            var review = Db.CarReviews.Find(id);

            return review;
        }

        public int Create(CarReview entity)
        {
            CarReview car = Db.CarReviews.Add(entity);
            if (entity == null || car == null) return 0;
            var count = Db.SaveChanges();

            return count;
        }

        public CarReview Update(int id)
        {
            var review = Db.CarReviews.Find(id);

            return review;
        }
        public int Update(CarReview entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            var changed = Db.SaveChanges();
            return changed;
        }

        public int DeleteConfirmed(CarReview entity)
        { 
            CarReview forDel= Db.CarReviews.Find(entity.Id);
            var deleted = Db.CarReviews.Remove(forDel);
            var count = Db.SaveChanges();
            if (deleted != null) return count;
            else return -1;
        }
    }
}