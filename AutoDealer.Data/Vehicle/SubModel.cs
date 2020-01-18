using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Vehicle
{
    public class SubModel : BaseEntity
    {
        public int ModelID { get; set; }

        [Display(Name = "زیر مدل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string SubModelTitle { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
