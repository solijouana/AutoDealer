using System;
using System.ComponentModel.DataAnnotations;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Dealer
{
    public class Dealer : BaseEntity
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        public DateTime CreateDate { get; set; }

        [Required]
        public string ImageName { get; set; }

    }
}
