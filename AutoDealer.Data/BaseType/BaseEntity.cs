using System.ComponentModel.DataAnnotations;

namespace AutoDealer.Data.BaseType
{
   public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
