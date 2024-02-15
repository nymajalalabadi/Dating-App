using Application.Extensions;
using Application.Security.PasswordHelper;
using Application.Senders.Mail;
using Application.Services.Interfaces;
using Domain.DTOs.Account;
using Domain.Entities.User;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Constructor

        private readonly IUserRepository _userRepository;

        private readonly IPasswordHelper _passwordHelper;

        private readonly IViewRender _viewRender;

        private readonly ISendMail _sendMail;

        public UserService(IUserRepository userRepository, IPasswordHelper passwordHelper, IViewRender viewRender, ISendMail sendMail)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
            _viewRender = viewRender;
            _sendMail = sendMail;
        }

        #endregion


        #region user

        public async Task<User?> GetAllUserByUserId(int userId)
        {
            return await _userRepository.GetAllUserByUserId(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        #endregion


        #region account

        public async Task<RegisterReuslt> RegisterUser(RegisterDTO register)
        {
            #region Validations

            if (await _userRepository.CheckExistsingEmail(register.Email))
            {
                return RegisterReuslt.EmailIsExist;
            }

            #endregion

            #region Set properties

            var user = new User()
            {
                Email = register.Email,
                Avatar = "Default.png",
                IsEmailActive = false,
                Mobile = null,
                Password = _passwordHelper.EncodePasswordMd5(register.Password),
                RegisterDate = DateTime.Now,
                UserName = register.Email.Split('@')[0]
            };

            #endregion

            #region Insert user

            await _userRepository.AddUser(user);
            await _userRepository.SaveChanges();

            #endregion

            #region Send email

            string body = _viewRender.RenderToStringAsync("VerigyRegisterAccount", new { });
            _sendMail.Send(user.Email, "فعالسازی حساب کاربری", body);

            #endregion

            return RegisterReuslt.Success;
        }

        public async Task<LoginResult> LoginUser(LoginDTO login)
        {
            var hashPassword = _passwordHelper.EncodePasswordMd5(login.Password);

            var user = await _userRepository.GetUserByEmailAndPassword(login.Email.ToLower().Trim(), hashPassword);

            #region Validations

            if (user is null)
                return LoginResult.UserNotFound;

            if (!user.IsEmailActive)
                return LoginResult.EmailNotActive;

            #endregion

            return LoginResult.Success;

        }

        #endregion
    }
}
