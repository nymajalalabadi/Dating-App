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

        public async Task<IActionResult> AddLike(string userName)
        {
            var sourceUserId = User.GetUserId();

            return Ok();
        }

        #endregion
    }
}
