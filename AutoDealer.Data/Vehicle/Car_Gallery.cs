using System.ComponentModel.DataAnnotations;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Vehicle
{
    public class Car_Gallery : BaseEntity
    {
        public int CarId { get; set; }

        [Required]
        public string ImageName { get; set; }

        public virtual Car Cars { get; set; }
    }
}
