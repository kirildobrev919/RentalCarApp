using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Contracts
{
    public interface ICarReview : IEntity
    {
        int CarId { get; set; }
        int Rating { get; set; }
        string ReviewerName { get; set; }
        string Review { get; set; }
    }
}
