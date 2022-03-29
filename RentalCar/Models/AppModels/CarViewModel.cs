using RentalCar.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalCar.Models.AppModels
{
    public class CarViewModel : ICarViewModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool Availability { get; set; }
        public int ReviewsCount { get; set; }
    }
}