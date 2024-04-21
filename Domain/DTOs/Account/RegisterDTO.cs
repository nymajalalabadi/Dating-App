﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Account
{
    public class RegisterDTO
    {
        #region Properties

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} می باشد")]
        [Compare(nameof(Password), ErrorMessage = "کلمه عبور و تکرار آن یکسان نمی باشد")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "نحوه آشنایی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string KnownAs { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string City { get; set; }

        [Display(Name = "کشور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Country { get; set; }

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Gender { get; set; }

        #endregion
    }

    public enum RegisterReuslt
    {
        Success,
        Error,
        EmailIsExist
    }
}
