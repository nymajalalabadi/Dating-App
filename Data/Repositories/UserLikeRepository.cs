using Data.Context;
using Domain.DTOs.UserLike;
using Domain.Entities.User;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserLikeRepository : IUserLikeRepository
    {
        #region Constructor

        private readonly DatingAppContext _context;

        public UserLikeRepository(DatingAppContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<UserLike> GetUserLike(int sourceUserId, int likedUserId)
        {
            return await _context.UserLikes.FirstOrDefaultAsync(u => u.SourceUserId ==  sourceUserId && u.LikedUserId == likedUserId);
        }

        public async Task<User> GetUserWithLikes(int userId)
        {
            return await _context.Users.Include(u => u.LikedUsers).FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<IEnumerable<LikeDTO>> GetUserLikes(string predicate, int userId)
        {
            var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();

            var likes = _context.UserLikes.AsQueryable();

            if (predicate == "liked")
            {

                likes = likes.Where(L => L.SourceUserId == userId);
                users = likes.Select(L => L.LikedUser);

            }

            if (predicate == "likedBy")
            {
                likes = likes.Where(L => L.LikedUserId == userId);
                users = likes.Select(L => L.SourceUser);
            }

            return await users.Select(u => new LikeDTO()
            {
                Username = u.UserName,
                KnownAs = u.KnowAs,
                Age = 45,
                PhotoUrl = u.Photos.FirstOrDefault(p => p.IsMain).Url,
                City = u.City,
                Id = u.UserId
            }).ToListAsync();
        }
    }
}
