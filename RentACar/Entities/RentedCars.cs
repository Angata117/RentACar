using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Entities
{
    public class RentedCars : BaseEntity
    {
        public DateTime RentedDateTime { get; set;}
        public int DaysRentedFor { get; set; }
        public int UserId { get; set; }
        public int ManagerId { get; set; }
        public int CarId { get; set; }
        public DateTime ReturnDateTime
        {
            get { return RentedDateTime.AddDays(DaysRentedFor); }
        }

        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [ForeignKey(nameof(ManagerId))]
        public virtual Manager Manager { get; set; }
    }
}
