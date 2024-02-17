using DatingApp.Api.Services.Interface;
using Domain.Entities.User;

namespace DatingApp.Api.Services.Implementation
{
    public class TokenService : ITokenService
    {
        #region Constructor

        public TokenService()
        {
            
        }

        #endregion


        #region token

        public string CreateToken(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
