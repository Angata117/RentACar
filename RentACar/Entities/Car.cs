using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string LicensePlate { get; set; }
        public int Mileage { get; set; }
        public string Damage { get; set; }
        public double PricePerDay { get; set; }

    }
}
