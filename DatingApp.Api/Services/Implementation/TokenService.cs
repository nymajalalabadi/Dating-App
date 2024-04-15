using DatingApp.Api.Services.Interface;
using Domain.Entities.User;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            _configuration = configuration;
        }

        #endregion


        #region token

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
               new Claim("UserId",user.UserId.ToString()),
               new Claim(JwtRegisteredClaimNames.NameId,user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                _configuration["Jwt:Issuer"],
               _configuration["Jwt:Issuer"],
               claims,
               expires: DateTime.Now.AddDays(7),
               signingCredentials: creds
               );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }

    #endregion
}
