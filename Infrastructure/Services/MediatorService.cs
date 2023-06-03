using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Infrastructure.Common;
using Infrastructure.Spends.Profiles;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class AddExtraService
    {
        public static IServiceCollection AddExtraServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var config = new MapperConfiguration(c =>
            {
                List<Type> types = typeof(SpendProfile).Assembly
                    .GetTypes()
                    .Where(e =>
                    !e.IsAbstract &&
                    !e.IsInterface &&
                    typeof(IProfileRegister)
                        .IsAssignableFrom(e) &&
                    typeof(Profile).IsAssignableFrom(e))
                    .ToList();

                foreach (var type in types)
                {
                    c.AddProfile(type);
                }

            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());



            services.AddHttpContextAccessor();
            


            //services.AddResponseCompression(options =>
            //{
            //    options.Providers.Add<GzipCompressionProvider>();
            //    options.EnableForHttps = true;
            //});
            //services.Configure<GzipCompressionProviderOptions>(options =>
            //{
            //    options.Level = CompressionLevel.Fastest;
            //});
            return services;
        }
    }
}
