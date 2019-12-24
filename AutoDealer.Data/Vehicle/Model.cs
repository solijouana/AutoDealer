using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Vehicle
{
    public class Model : BaseEntity
    {
        public int ManufacturerId { get; set; }

        [Display(Name = "مدل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string ModelTitle { get; set; }

        [Display(Name = "حذف")]
        public bool IsDelete { get; set; }

        public Nullable<int> ParentID { get; set; }

        public virtual Model Model1 { get; set; }
        public virtual ICollection<Model> Model2 { get; set; }
        public virtual Manufacturer Manufacturers { get; set; }

    }
}
