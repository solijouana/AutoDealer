using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Vehicle
{
    public class Option_Category : BaseEntity
    {
        [Display(Name = "دسته بندی آپشن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Op_CategortyTitle { get; set; }

        [Display(Name = "حذف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsDelete { get; set; }

        public virtual ICollection<Option> Options { get; set; }
    }
}
