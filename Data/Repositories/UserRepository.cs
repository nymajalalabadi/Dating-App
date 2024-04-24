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
            return await _context.Users.Include(u => u.Photos).ToListAsync();
        }

        public async Task<bool> CheckExistsingEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChanges()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAndPassword(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public async Task<User?> GetUserByUserName(string userName)
        {
            return await _context.Users.Include(u => u.Photos).FirstOrDefaultAsync(u => u.UserName.Contains(userName.Trim()));
        }

        public async Task<User?> GetUserByUserId(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId.Equals(userId));
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        #endregion
    }
}
