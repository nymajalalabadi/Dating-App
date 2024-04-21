using Application.Extensions;
using Application.Extensions.Common;
using Application.Security.PasswordHelper;
using Application.Senders.Mail;
using Application.Services.Interfaces;
using Domain.DTOs.Account;
using Domain.DTOs.Photo;
using Domain.DTOs.User;
using Domain.Entities.User;
using Domain.Interfaces;

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
                Email = register.Email.ToLower().Trim(),
                Avatar = "Default.png",
                IsEmailActive = false,
                Mobile = null,
                Password = _passwordHelper.EncodePasswordMd5(register.Password),
                RegisterDate = DateTime.Now,
                UserName = register.Email.Split('@')[0],
                City = register.City,
                Country = register.Country,
                DateOfBirth = register.DateOfBirth,
                Gender = register.Gender,
                KnowAs = register.KnownAs
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


        #region user

        public async Task<User?> GetAllUserByUserId(int userId)
        {
            return await _userRepository.GetAllUserByUserId(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }



        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<List<MemberDTO>> GetAllUserInformation()
        {
            var users = await _userRepository.GetAllUsers();

            return users.Select(u => new MemberDTO()
            {
                UserId = u.UserId,
                PhotoUrl = $"https://localhost:7220/images/users/{u.Avatar}",
                Age = u.DateOfBirth.CalculateAge(),
                City = u.City,
                Country = u.Country,
                Email = u.Email,
                Gender = u.Gender,
                Interests = u.Interests,
                Introduction = u.Introduction,
                IsEmailActive = u.IsEmailActive,
                KnowAs = u.KnowAs,
                LookingFor = u.LookingFor,
                Mobile = u.Mobile,
                RegisterDate = u.RegisterDate,
                UserName = u.UserName,
                Photos = u.Photos.Select(p => new PhotoDTO()
                {
                    Id = p.Id,
                    IsMain = p.IsMain,
                    Url = p.Url
                }).ToList()
            }).ToList();


        }

        public async Task<MemberDTO?> GetUserInformationByUserName(string userName)
        {
            var user = await _userRepository.GetUserByUserName(userName);

            if (user == null)
                return null;

            return new MemberDTO()
            {
                UserId = user.UserId,
                PhotoUrl = $"https://localhost:7220/images/users/{user.Avatar}",
                Age = user.DateOfBirth.CalculateAge(),
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                Gender = user.Gender,
                Interests = user.Interests,
                Introduction = user.Introduction,
                IsEmailActive = user.IsEmailActive,
                KnowAs = user.KnowAs,
                LookingFor = user.LookingFor,
                Mobile = user.Mobile,
                RegisterDate = user.RegisterDate,
                UserName = user.UserName,
                Photos = user.Photos.Select(p => new PhotoDTO()
                {
                    Id = p.Id,
                    IsMain = p.IsMain,
                    Url = p.Url
                }).ToList()
            };
        }

        public async Task<bool> UpdateMember(UpdateMemberDTO model, int userId)
        {
            var user = await _userRepository.GetAllUserByUserId(userId);

            if (user == null) return false;

            user.Introduction = model.Introduction;
            user.Interests = model.Intrests;
            user.LookingFor = model.LookingFor;
            user.City = model.City;
            user.Country = model.Country;

            _userRepository.UpdateUser(user);
            await _userRepository.SaveChanges();

            return true;
        }

        #endregion
    }
}
