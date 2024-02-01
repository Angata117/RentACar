using System.ComponentModel.DataAnnotations;

namespace RentACar.ViewModels.Users
{
    public class CreateVM
    {
        [Required(ErrorMessage = "This field is Required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "The field for EGN must be exactly 10 and only digits.")]
        public string EGN { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "The field for phone number must be exactly 10 and only digits.")]
        public string PhoneNumber { get; set; }
    }
}
