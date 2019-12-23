using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Vehicle
{
    public class Manufacturer:BaseEntity
    {
        [Display(Name ="شرکت سازنده")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string ManufacturerName { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
