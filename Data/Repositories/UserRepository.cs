using Data.Context;
using Domain.Entities.User;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Constructor

        private readonly DatingAppContext _context;

        public UserRepository(DatingAppContext context)
        {
            _context = context;
        }

        #endregion

        #region user

        public async Task<User?> GetAllUserByUserId(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);   
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        #endregion
    }
}
