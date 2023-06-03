using DataAccess.Persistence;
using Infrastructure.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public static class ServicesLifeSpan
    {
        public static IServiceCollection AddServicesLifeSpan(this IServiceCollection services)
        {
            services.AddTransient<IPersistence, Persistence>();
            services.AddSingleton<AzCultureInfo>();
            return services;
        }
    }
}
