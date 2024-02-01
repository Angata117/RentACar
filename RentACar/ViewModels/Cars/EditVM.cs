using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RentACar.ViewModels.Cars
{
    public class EditVM
    {
        public int Id { get; set; }
        public int Mileage { get; set; }
        public string Damage { get; set; }
        public double PricePerDay { get; set; }
       
    }
}
