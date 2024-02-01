using RentACar.Entities;
using System.ComponentModel;

namespace RentACar.ViewModels.Users
{
    public class IndexVM
    {
        public List<User> Items { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("EGN")]
        public string EGN { get; set; }
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }
    }
}
