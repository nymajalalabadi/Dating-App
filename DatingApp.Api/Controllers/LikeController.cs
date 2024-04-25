using Application.Extensions;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    public class LikeController : BaseSiteController
    {
        #region constructor

        private readonly IUserLikeService _userLikeService;

        public LikeController(IUserLikeService userLikeService)
        {
               _userLikeService = userLikeService;
        }

        #endregion

        #region add Like

        [HttpPost("{userName}")]
        public async Task<IActionResult> AddLike(string userName)
        {
            var sourceUserId = User.GetUserId();

            var result = await _userLikeService.AddUserLikeAsync(sourceUserId, userName);

            if (result)
            {
                return new JsonResult(new
                {
                    Message = "عملیات با موفقیت انجام شد",
                    StatusCode = 200,
                    IsSuccess = true
                });
            }
            else
            {
                return new JsonResult(new
                {
                    Message = "Has error",
                    StatusCode = 201,
                    IsSuccess = false
                });
            }

        }

        #endregion

        #region Get user like

        [HttpGet]
        public async Task<IActionResult> GetUserLikes(string predicate)
        {
            var users = await _userLikeService.GetUserLikes(predicate, User.GetUserId());

            return Ok(users);
        }

        #endregion
    }
}
