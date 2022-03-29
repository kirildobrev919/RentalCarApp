using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Contracts
{
    public interface ICarViewModel : IEntity
    {
        string Make { get; set; }
        string Model { get; set; }
        bool Availability { get; set; }
        int ReviewsCount { get; set; }
    }
}
