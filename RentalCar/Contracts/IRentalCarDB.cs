using RentalCar.Models;
using RentalCar.Models.AppModels;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Contracts
{
    public interface IRentalCarDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
    }
}
