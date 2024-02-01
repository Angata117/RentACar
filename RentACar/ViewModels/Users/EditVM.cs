using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RentACar.ViewModels.Users
{
    public class EditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "The field for EGN must be exactly 10 and only digits.")]
        public string EGN { get; set; }
        [Required(ErrorMessage = "This field is Required!")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "The field for phone number must be exactly 10 and only digits.")]
        public string PhoneNumber { get; set; }
    }
}
