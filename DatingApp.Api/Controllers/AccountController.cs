using Application.Services.Interfaces;
using Domain.DTOs.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

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
            RegisterReuslt res = await _userService.RegisterUser(register);

            switch (res)
            {
                case RegisterReuslt.Success:
                    TempData["SuccessMessage"] = "حساب کاربری شما با موفقیت ساخته شد.";
                    break;

                case RegisterReuslt.Error:
                    TempData["ErrorMessage"] = "مشکلی پیش آمده است. لطفا مجدد تلاش کنید";
                    break;

                case RegisterReuslt.EmailIsExist:
                    TempData["ErrorMessage"] = "ایمیل وارد شده از قبل ثبت نام کرده است.";
                    break;

                default:
                    break;
            }


            return Ok();
        }

        #endregion


        #region login

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            return Ok();
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
