using System.ComponentModel.DataAnnotations;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Vehicle
{
    public class Option : BaseEntity
    {
        [Display(Name = "آپشن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string OptionTitle { get; set; }

        [Display(Name = "حذف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsDelete { get; set; }

        public int Op_CategoryID { get; set; }
        public virtual Option_Category OptionCategory { get; set; }
    }
}
