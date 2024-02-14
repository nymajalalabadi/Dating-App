using Application.Extensions;
using Application.Senders.Mail;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dependencies
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Service

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ISendMail, SendMail>();

            services.AddScoped<IViewRender, RenderViewToString>();

            #endregion


            #region Repository

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }

    }
}
