using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.Entities;
using Japp.EFCore.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Japp.BusinessLayer.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityExtensions(this IServiceCollection services, IConfiguration config)
        {
            // services.AddIdentity<Member, IdentityRole>()
            //         .AddEntityFrameworkStores<DataContext>()
            //         .AddDefaultTokenProviders();
            services.AddIdentityCore<Member>().AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

            services.Configure<PasswordHasherOptions>(options =>
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
            );

            return services;
        }
    }
}