using DatingApp.Api.Services.Interface;
using Domain.Entities.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatingApp.Api.Services.Implementation
{
    public class TokenService : ITokenService
    {
        #region Constructor

        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(configuration["TokenKey"]));
        }

        #endregion


        #region token

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
               new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }

    #endregion
}
