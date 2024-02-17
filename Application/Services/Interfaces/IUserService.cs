using Domain.DTOs.Account;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        #region user

        Task<User?> GetAllUserByUserId(int userId);

        Task<IEnumerable<User>> GetAllUsers();

        #endregion


        #region account

        Task<RegisterReuslt> RegisterUser(RegisterDTO register);

        Task<LoginResult> LoginUser(LoginDTO login);

        Task<User?> GetUserByEmail(string email);

        #endregion
    }
}
