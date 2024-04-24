using Domain.DTOs.UserLike;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserLikeRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);

        Task<User> GetUserWithLikes(int userId);

        Task<IEnumerable<LikeDTO>> GetUserLikes(string predicate, int userId);
    }
}
