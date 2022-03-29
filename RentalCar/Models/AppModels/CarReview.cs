using RentalCar.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentalCar.Models.AppModels
{
    public class CarReview : ICarReview
    {
        public int Id { get; set; }
        public int CarId { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        [StringLength(32)]
        public string ReviewerName { get; set; }

        [StringLength(192)]
        public string Review { get; set; }
    }
}