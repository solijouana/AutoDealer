using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoDealer.Data.BaseType;
using AutoDealer.Services.DTO.WebLog;

namespace AutoDealer.Services.DTO.User
{
    public class User : BaseEntity
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "کاراکترهای وارد شده بیشتر از {0} است")]
        public string FullName { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "کاراکترهای وارد شده بیشتر از {0} است")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "کاراکترهای وارد شده بیشتر از {0} است")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "کاراکترهای وارد شده بیشتر از {0} است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "شماره تماس")]
        public int? Phone { get; set; }

        [Display(Name = "تصویر کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "کاراکترهای وارد شده بیشتر از {0} است")]
        public string ImageName { get; set; }

        [Display(Name = "حذف شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsDelete { get; set; }

        public virtual List<Blog> Blogs { get; set; }
    }
}
