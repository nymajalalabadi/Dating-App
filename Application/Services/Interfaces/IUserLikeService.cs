using Domain.DTOs.UserLike;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserLikeService
    {
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);

        Task<User> GetUserWithLikes(int userId);

        Task<IEnumerable<LikeDTO>> GetUserLikes(string predicate, int userId);

        Task<bool> AddUserLikeAsync(int sourceUserId, string userName);
    }
}
