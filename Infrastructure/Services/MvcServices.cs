using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class MvcServices
    {
        public static IServiceCollection AddMvcServices(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });


            services.ConfigureApplicationCookie(option =>
            {
                option.AccessDeniedPath = new PathString("/Panel/Dashboard/AccessDenied");
                option.LoginPath = new PathString("/account/login");
            });

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.FromMinutes(30);
            });


            return services;
        }
    }
}
