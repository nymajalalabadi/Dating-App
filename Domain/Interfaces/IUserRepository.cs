﻿using Domain.Entities.User;
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

        Task<bool> CheckExistsingEmail(string email);

        Task AddUser(User user);

        Task SaveChanges();

        Task<User?> GetUserByEmailAndPassword(string email, string password);

        Task<User?> GetUserByEmail(string email);

        #endregion
    }
}
