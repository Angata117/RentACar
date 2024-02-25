using System.ComponentModel.DataAnnotations;

namespace RentACar.ViewModels.Cars
{
    public class CreateVM
    {
        [Required(ErrorMessage = "This field is Required!")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public string LicensePlate { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field is only for digits!")]
        public int Mileage { get; set; }
        public string? Damage { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field is only for digits!")]
        public double PricePerDay { get; set; }
    }
}
