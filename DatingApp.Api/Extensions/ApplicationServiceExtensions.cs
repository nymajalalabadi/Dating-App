using Data.Context;
using DatingApp.Api.Services.Implementation;
using DatingApp.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();

            #region context

            services.AddDbContext<DatingAppContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DatingAppConnectionString"));
            });

            #endregion


            return services;
        }
    }

}
