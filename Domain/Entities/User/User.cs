using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities.User
{
    public class User
    {
        #region properties

        [Key]
        public int UserId { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string Password { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "شماره موبایل")]
        [MaxLength(11, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string? Mobile { get; set; }

        [Display(Name = "آواتار")]
        [MaxLength(50, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string Avatar { get; set; }

        [Display(Name = "ایمیل فعال باشد؟")]
        public bool IsEmailActive { get; set; }

        [Display(Name = "تاریخ تولد کاربر")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Display(Name = "اخرین فعالیت کاربر")]
        public DateTime LastActive { get; set; } = DateTime.Now;

        [Display(Name = "جنسیت کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Gender { get; set; }

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Interests { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string City { get; set; }

        [Display(Name = "کشور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Country { get; set; }

        [Display(Name = "نحوه آشنایی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string KnowAs { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        #endregion

        #region Relations

        public ICollection<Photo.Photo> Photos { get; set; }

        #endregion

    }
}
