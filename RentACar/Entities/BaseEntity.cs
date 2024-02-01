using System.ComponentModel.DataAnnotations;

namespace RentACar.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
