using System;
using Japp.Core.Entities;
using Japp.EFCore.Context;
using Japp.EFCore.Repositories.Benefits;
using Japp.EFCore.Repositories.Comments;
using Japp.EFCore.Repositories.Companies;
using Japp.EFCore.Repositories.Jobs;
using Japp.EFCore.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Japp.EFCore
{
    public static class EFCoreExtensions
    {
        public static IServiceCollection AddEFCore(
                this IServiceCollection services,
                Action<DbContextOptionsBuilder> dboptions,
                ServiceLifetime scope = ServiceLifetime.Scoped)
        {
            
            services.AddDbContext<DataContext>(dboptions, ServiceLifetime.Transient);
            services.AddIdentity<Member, IdentityRole>()
                    .AddEntityFrameworkStores<DataContext>()
                    .AddDefaultTokenProviders();

            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<IBenefitRepository, BenefitRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            
            return services;
        }
    }
}
