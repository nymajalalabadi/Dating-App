using Application.Services.Interfaces;
using Domain.DTOs.Account;
using Domain.DTOs.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Win32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatingApp.Api.Controllers
{
    public class AccountController : BaseSiteController
    {
        #region Constructor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
               _userService = userService;
        }

        #endregion

        #region register

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();

                foreach (var modelError in ViewData.ModelState.Values)
                {
                    foreach (var error in modelError.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                return new JsonResult(new ResponseResult(false, "", errors));
            }

            #endregion


            var res = await _userService.RegisterUser(register);

            switch (res)
            {
                case RegisterReuslt.Success:
                    return new JsonResult(new ResponseResult(true, "حساب کاربری شما با موفقیت ساخته شد."));

                case RegisterReuslt.Error:
                    return new JsonResult(new ResponseResult(false, "مشکلی پیش آمده است. لطفا مجدد تلاش کنید"));

                case RegisterReuslt.EmailIsExist:
                    return new JsonResult(new ResponseResult(false, "ایمیل وارد شده از قبل ثبت نام کرده است."));

                default:
                    break;
            }


            return new JsonResult(new ResponseResult(false, "خطایی رخ داده است."));
        }

        #endregion


        #region login

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();

                foreach (var modelError in ViewData.ModelState.Values)
                {
                    foreach (var error in modelError.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                return new JsonResult(new ResponseResult(false, "", errors));
            }

            #endregion

            var res = await _userService.LoginUser(login);

            switch (res)
            {
                case LoginResult.Success:
                    return new JsonResult(new ResponseResult(true, "به سایت ما خوش امدی"));

                case LoginResult.Error:
                    return new JsonResult(new ResponseResult(false, "مشکلی پیش آمده است. لطفا مجدد تلاش کنید"));

                case LoginResult.EmailNotActive:
                    return new JsonResult(new ResponseResult(false, "حساب کابری شما فعال نشده است . لطفا ایمیل خود را فعال کنید"));
                default:
                    break;
            }


            return new JsonResult(new ResponseResult(false, "خطایی رخ داده است."));
        }

        #endregion


        #region forgot-password

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPassword)
        {
            return Ok();
        }

        #endregion
    }
}
