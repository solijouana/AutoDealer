using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Services.DTO.WebLog
{
    public class Blog : BaseEntity
    {
        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "کاراکترهای وارد شده بیشتر از {0} است")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [Display(Name = "تاریخ درج")]
        [Required]
        public DateTime CreateDate { get; set; }

        [Display(Name = "کلید واژه ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "کاراکترهای وارد شده بیشتر از {0} است")]
        public string Tags { get; set; }

        [Display(Name = "حذف شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsDelete { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "کاراکترهای وارد شده بیشتر از {0} است")]
        public string ImageName { get; set; }


        public virtual User.User User { get; set; }
    }
}
