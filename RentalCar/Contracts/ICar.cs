using RentalCar.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Contracts
{
    public interface ICar : IEntity
    {
        string Make { get; set; }
        string Model { get; set; }
        bool Availability { get; set; }
        List<CarReview> Reviews { get; set; }
    }
}
