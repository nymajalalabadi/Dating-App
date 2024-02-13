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

        Task<User?> GetAllUserByUserId(int userId);

        #endregion
    }
}
