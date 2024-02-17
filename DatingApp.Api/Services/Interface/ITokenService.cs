using Domain.Entities.User;

namespace DatingApp.Api.Services.Interface
{
    public interface ITokenService
    {
        #region token

        string CreateToken(User user);

        #endregion
    }
}
