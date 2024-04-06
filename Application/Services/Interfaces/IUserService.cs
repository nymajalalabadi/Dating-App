using Domain.DTOs.Account;
using Domain.DTOs.User;
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
        #region Account

        Task<RegisterReuslt> RegisterUser(RegisterDTO registerDTO);

        Task<LoginResult> LoginUser(LoginDTO loginDTO);

        #endregion

        #region User

        Task<IEnumerable<User>> GetAllUsers();

        Task<User?> GetAllUserByUserId(int userId);

        Task<User?> GetUserByEmail(string email);

        Task<List<MemberDTO>> GetAllUserInformation();

        Task<MemberDTO> GetUserInformationByUserName(string userName);

        Task<bool> UpdateMember(UpdateMemberDTO model, int userId);

        #endregion

    }
}
