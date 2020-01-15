using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Vehicle
{
    public class Model : BaseEntity
    {

        [Display(Name = "مدل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string ModelTitle { get; set; }

        public int ManufacturerID { get; set; }

        [Display(Name = "حذف")]
        public bool IsDelete { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<SubModel>SubModels { get; set; }

    }
}
    