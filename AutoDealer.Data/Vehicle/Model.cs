using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
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

        public virtual Manufacturer Manufacturers { get; set; }

        public virtual ICollection<SubModel> SubModels { get; set; }

    }
}
