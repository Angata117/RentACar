﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RentACar.ViewModels.Cars
{
    public class EditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field is only for digits!")]
        public int Mileage { get; set; }
        public string? Damage { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field is only for digits!")]
        public double PricePerDay { get; set; }
       
    }
}
