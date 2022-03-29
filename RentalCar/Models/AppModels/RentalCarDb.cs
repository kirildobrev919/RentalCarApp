using RentalCar.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalCar.Models.AppModels
{
    public class RentalCarDb : DbContext, IRentalCarDb
    {
        public RentalCarDb()
    : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarReview> CarReviews { get; set; }
        //public DbSet<UserProfile> UserProfiles { get; set; }

        IQueryable<T> IRentalCarDb.Query<T>()
        {
            return Set<T>();
        }

        public static RentalCarDb Create()
        {
            return new RentalCarDb();
        }
    }
}