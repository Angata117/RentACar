using System.ComponentModel.DataAnnotations;

namespace RentACar.Entities
{
    public class Manager : BaseEntity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "The field for phone number must be exactly 10 and only digits.")]
        public string PhoneNumber { get; set; }
    }
}
