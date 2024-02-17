using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DatingApp.Api.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(configuration.GetSection("TokenKey").ToString())),
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            return services;
        }
    }

}
