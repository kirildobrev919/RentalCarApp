using RentalCar.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
//using System.Data.Entity;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace RentalCar.Models.AppModels
{
    public class CarRepository : IRepository<Car>   
    {
        public RentalCarDb Db { get; set; }

        public CarRepository()
        {
            Db = new RentalCarDb();
        }

        public ICollection<Car> Read()
        {
            var cars = Db.Cars
                       .Include("Reviews");
            return cars.ToList<Car>();
        }

        public Car Read(int id)
        {            
            var car = Db.Cars
                .Include("Reviews")
                .FirstOrDefault(c => c.Id == id);

            return car;
        }

        public int Create(Car entity)
        {
            var result = 0;
            if (entity == null) return result;
            Db.Cars.Add(entity);
            result = Db.SaveChanges();
            return result;
        }

        public Car Update(int id)
        {
            var car = Read(id);
            return car;
        }

        public int Update(Car entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            var changed = Db.SaveChanges();
            return changed;
        }

        public int DeleteConfirmed(Car entity)
        {           
            Car forDel = Db.Cars.Find(entity.Id);
            var deleted = Db.Cars.Remove(forDel);
            var result = Db.SaveChanges();
            if (deleted != null) return result;
            else return -1;
        }
    }
}