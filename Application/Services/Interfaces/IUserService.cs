using Domain.DTOs.Account;
using Domain.DTOs.Common;
using Domain.DTOs.User;
using Domain.Entities.User;

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

        Task<PagedList<MemberDTO>> GetAllUserInformation(UserParams model);

        Task<MemberDTO> GetUserInformationByUserName(string userName);

        Task<bool> UpdateMember(UpdateMemberDTO model, int userId);

        #endregion

    }
}
