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

        private readonly IUserRepository _userRepository;

        public UserLikeService(IUserLikeRepository userLikeRepository, IUserRepository userRepository) 
        {
            _userLikeRepository = userLikeRepository;
            _userRepository = userRepository;
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
            return await _userLikeRepository.GetUserLikes(predicate, userId);
        }

        public async Task<bool> AddUserLikeAsync(int sourceUserId, string userName)
        {
            var likedUser = await _userRepository.GetUserByUserName(userName);

            var sourceUser = await _userRepository.GetUserByUserId(sourceUserId);

            if (likedUser == null)
                return false;

            if (sourceUser.UserName == userName)
                return false;

            var userLike = await _userLikeRepository.GetUserLike(sourceUserId, likedUser.UserId);

            if (userLike != null)
                return false;

            userLike = new UserLike()
            {
                SourceUserId = sourceUser.UserId,
                LikedUserId = likedUser.UserId
            };

            await _userLikeRepository.AddUserLike(userLike);
            await _userLikeRepository.SaveChanges();

            return true;
        }
    }
}
