using System.ComponentModel.DataAnnotations;

namespace RentACar.Entities
{
    public class User : BaseEntity 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "The field for EGN must be exactly 10 and only digits.")]
        public string EGN { get; set; }
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "The field for phone number must be exactly 10 and only digits.")]
        public string PhoneNumber{ get; set; }
    }
}
