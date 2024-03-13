using Application.Services.Interfaces;
using DatingApp.Api.Services.Interface;
using Domain.DTOs.Account;
using Domain.DTOs.Common;
using Domain.DTOs.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    public class AccountController : BaseSiteController
    {
        #region Constructor

        private readonly IUserService _userService;

        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
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
                    foreach (var error in modelError.Errors)
                        errors.Add(error.ErrorMessage);

                return new JsonResult(new ResponseResult(false, "", errors));
            }

            #endregion

            RegisterReuslt res = await _userService.RegisterUser(register);
            switch (res)
            {
                case RegisterReuslt.Success:

                    var user = await _userService.GetUserByEmail(register.Email);
                    if (user == null)
                        return new JsonResult(new ResponseResult(false, "متاسفانه حساب کاربری شفا یافت نشد."));


                    return new JsonResult(new ResponseResult(true, "حساب کاربری شما با موفقیت ساخته شد.", new UserDTO
                    {
                        UserName = user.UserName,
                        Token = _tokenService.CreateToken(user)
                    }));

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            LoginResult res = await _userService.LoginUser(login);

            switch (res)
            {
                case LoginResult.Success:

                    var user = await _userService.GetUserByEmail(login.Email);
                    if (user == null)
                        return new JsonResult(new ResponseResult(false, "متاسفانه حساب کاربری شفا یافت نشد."));

                    return new JsonResult(new ResponseResult(true, "شما با موفقیت وارد حساب کاربری خودتون شدید.", new UserDTO
                    {
                        UserName = user.UserName,
                        Token = _tokenService.CreateToken(user)
                    }));

                case LoginResult.Error:
                    return new JsonResult(new ResponseResult(false, "مشکلی پیش آمده است. لطفا مجدد تلاش کنید"));

                case LoginResult.EmailNotActive:
                    return new JsonResult(new ResponseResult(false, "حساب کاربری شما فعال نشده است. لطفا ابتدا حساب کاربری خودتون رو فعال کنید."));

                default:
                    break;
            }

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

        #region logout

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return new JsonResult(new ResponseResult(true, "عملیات خروج با موفقیت انجام شد"));
        }

        #endregion
    }
}
