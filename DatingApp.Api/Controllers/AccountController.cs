using Domain.DTOs.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DatingApp.Api.Controllers
{
    public class AccountController : BaseSiteController
    {
        #region Constructor

        public AccountController()
        {
               
        }

        #endregion

        #region register

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
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
