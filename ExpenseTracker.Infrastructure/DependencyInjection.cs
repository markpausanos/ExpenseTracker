using ExpenseTracker.Application.Common.Interfaces.Authentication;
using ExpenseTracker.Application.Common.Interfaces.Services;
using ExpenseTracker.Infrastructure.Authentication;
using ExpenseTracker.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ExpenseTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configurationManager
        )
        {
            services.Configure<JWTSettings>(configurationManager.GetSection(JWTSettings.SectionName));

            services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
