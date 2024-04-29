using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        #region user

        Task<IEnumerable<User>> GetAllUsers();

        IQueryable<User> GetAllUsersAsQueryable();

        Task<User?> GetAllUserByUserId(int userId);

        Task<bool> CheckExistsingEmail(string email);

        Task AddUser(User user);

        Task SaveChanges();

        Task<User?> GetUserByEmailAndPassword(string email, string password);

        Task<User?> GetUserByEmail(string email);

        Task<User?> GetUserByUserName(string userName);

        Task<User?> GetUserByUserId(int userId);

        void UpdateUser(User user);

        #endregion
    }
}
