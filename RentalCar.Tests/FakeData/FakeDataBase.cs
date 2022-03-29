using RentalCar.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalCar.Models.AppModels
{
    public class FakeRentalCarDb : IRentalCarDb
    {

        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();
        public FakeRentalCarDb()
        {

        }
        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof(T)] as IQueryable<T>;
        }

        public void Dispose()
        {

        }

        public void AddSets<T>(IQueryable<T> objs)
        {
            if (Sets.Count != 0) { }
            else Sets.Add(typeof(T), objs);
        }
    }
}