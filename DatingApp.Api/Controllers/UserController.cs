using Application.Extensions;
using Application.Services.Interfaces;
using DatingApp.Api.Extensions;
using Domain.DTOs.User;
using Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> Get([FromQuery]UserParams model)
        {
            model.UserId = User.GetUserId();

            var users = await _userService.GetAllUserInformation(model);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPage);

            return Ok(users);
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
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UpdateMemberDTO updateMember)
        {
            var userId = User.GetUserId();

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
