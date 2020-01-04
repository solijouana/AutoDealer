using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoDealer.Data.BaseType;

namespace AutoDealer.Data.Vehicle
{
    public class Car : BaseEntity
    {
        public int ManufacturerId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "سال ساخت")]
        public string ProductionDate { get; set; }

        [Display(Name = "تیپ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Type { get; set; }

        [Display(Name = "نوع سوخت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Fuel { get; set; }

        [Display(Name = "جعبه دنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Transmition { get; set; }

        [Display(Name = "درب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Doors { get; set; }

        [Display(Name = "رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Color { get; set; }

        [Display(Name = "کارکرد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Trip { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "تاریخ درج")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }

        [Display(Name = "حذف")]
        public bool IsDelete { get; set; }

        [Display(Name = "آگهی ویژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool Specific { get; set; }

        public virtual ICollection<Car_Gallery> CarGalleries { get; set; }
        public virtual Manufacturer Manufacturers { get; set; }
    }
}
