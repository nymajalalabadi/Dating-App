using Application.Services.Interfaces;
using Domain.DTOs.UserLike;
using Domain.Entities.User;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class UserLikeService : IUserLikeService
    {
        #region Constructor

        private readonly IUserLikeRepository _userLikeRepository;

        public UserLikeService(IUserLikeRepository userLikeRepository) 
        {
            _userLikeRepository = userLikeRepository;
        }

        #endregion

        public async Task<UserLike> GetUserLike(int sourceUserId, int likedUserId)
        {
            return await _userLikeRepository.GetUserLike(sourceUserId, likedUserId);
        }

        public async Task<User> GetUserWithLikes(int userId)
        {
            return await _userLikeRepository.GetUserWithLikes(userId);
        }

        public async Task<IEnumerable<LikeDTO>> GetUserLikes(string predicate, int userId)
        {

        }
    }
}
