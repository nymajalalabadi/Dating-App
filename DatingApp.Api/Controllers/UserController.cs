using Application.Services.Interfaces;
using Domain.DTOs.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp.Api.Controllers
{
    public class UserController : BaseSiteController
    {

        #region Constructor

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllUserInformation());
        }

        // GET api/<UserController>/5
        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            return Ok(await _userService.GetUserInformationByUserName(userName));
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateMemberDTO updateMember)
        {
            var userId = 1;

            var result = await _userService.UpdateMember(updateMember, userId);

            if (result)
            {
                return new JsonResult(new
                {
                    Message = "updated",
                    StatusCode = 200,
                    IsSuccess = true
                });
            }

            return new JsonResult(new
            {
                Message = "Has error",
                StatusCode = 201,
                IsSuccess = false
            });
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
