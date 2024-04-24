using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string? UserName { get; set; }

        [Display(Name = "شماره موبایل")]
        public string? Mobile { get; set; }

        [Display(Name = "آواتار")]
        public string? Avatar { get; set; }

        [Display(Name = "ایمیل فعال باشد؟")]
        public bool IsEmailActive { get; set; }

        [Display(Name = "تاریخ تولد کاربر")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Display(Name = "اخرین فعالیت کاربر")]
        public DateTime LastActive { get; set; } = DateTime.Now;

        [Display(Name = "جنسیت کاربر")]
        public string? Gender { get; set; }

        public string? Introduction { get; set; }

        public string? LookingFor { get; set; }

        public string? Interests { get; set; }

        [Display(Name = "شهر")]
        public string? City { get; set; }

        [Display(Name = "کشور")]
        public string? Country { get; set; }

        [Display(Name = "نحوه آشنایی")]
        public string? KnowAs { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        #endregion

        #region Relations

        public ICollection<Photo.Photo> Photos { get; set; }

        [InverseProperty("SourceUser")]
        public ICollection<UserLike> LikedByUsers { get; set; }

        [InverseProperty("LikedUser")]
        public ICollection<UserLike> LikedUsers { get; set; }

        #endregion

    }
}
