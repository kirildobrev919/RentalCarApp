using RentalCar.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentalCar.Models.AppModels
{
    public class Car: ICar
    {
        public int Id { get; set; }
        [StringLength(16)]
        public string Make { get; set; }
        [StringLength(16)]
        public string Model { get; set; }
        public bool Availability { get; set; }
        public virtual List<CarReview> Reviews { get; set; }
    }
}