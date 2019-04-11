using BaseJWT.Domain.Entity;
using BaseJWT.Domain.Interface;
using BaseJWT.Infrastructure.EntityFramework.Context;
using BaseJWT.Infrastructure.EntityFramework.UnitOfWork;
using BaseJWT.Infrastructure.Security;
using BaseJWT.Infrastructure.Security.Events;
using BaseJWT.Infrastructure.Security.Validation;
using BaseJWT.Service.Interface;
using BaseJWT.Service.Security;
using BaseJWT.Util.Domain;
using BaseJWT.Util.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWT.Service.Injection
{
    public class IocInfrastructure
    {
        public static void Set(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Configure Authentication

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IServiceCollection>(services);

            services.AddScoped<UserRegistrationAssertion>();

            services.AddScoped<IHandler<UserRegisterEvent>, UserRegisterComplated>();

            services.AddScoped<IAssertion, Assertions>();

        }

    }
}
