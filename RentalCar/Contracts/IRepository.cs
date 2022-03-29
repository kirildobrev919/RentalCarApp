using RentalCar.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Contracts
{
    public interface IRepository<T> where T : class
    {
        RentalCarDb Db { get; set; }
        ICollection<T> Read();
        T Read(int entity);
        int Create(T entity);
        T Update(int id);
        int Update(T entity);
        int DeleteConfirmed(T entity);
    }
}
