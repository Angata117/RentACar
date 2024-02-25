using System.ComponentModel.DataAnnotations;

namespace RentACar.ViewModels.Cars
{
    public class RentCarVM
    {
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field is only for digits!")]
        public int DaysRentedFor { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "This field is only for digits!")]
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int ManagerId { get; set; }
    }
}
