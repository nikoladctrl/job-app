using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Japp.BusinessLayer.Mappings;
using Japp.BusinessLayer.Services.Accounts;
using Japp.BusinessLayer.Services.Benefits;
using Japp.BusinessLayer.Services.Comments;
using Japp.BusinessLayer.Services.Companies;
using Japp.BusinessLayer.Services.Jobs;
using Japp.BusinessLayer.Services.Members;
using Japp.BusinessLayer.Services.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Japp.BusinessLayer
{
    public static class BusinessLayerExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var profileList = new List<Profile>();

            profileList.Add(new MappingBenefits());
            profileList.Add(new MappingComments());
            profileList.Add(new MappingCompanies());
            profileList.Add(new MappingJobs());
            profileList.Add(new MappingMembers());
            profileList.Add(new MappingTechnologies());

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBenefitService, BenefitService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAutoMapper(c => c.AddProfiles(profileList), typeof(List<Profile>));
            
            return services;
        }
    }
}