using RentACar.Entities;
using System.ComponentModel;

namespace RentACar.ViewModels.Cars
{
    public class IndexVM
    {
        public List<Car> Items { get; set; }
        public int Id { get; set; }
        [DisplayName("Brand")]
        public string Brand { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("License plate")]
        public string LicensePlate { get; set; }
        [DisplayName("Mileage")]
     
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }
    }
}
