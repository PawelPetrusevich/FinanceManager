using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinanceManagerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FinanceManagerConnection")), ServiceLifetime.Transient);

            services.AddTransient<IFinanceManagerContext>(provider => provider.GetService<FinanceManagerContext>());

            return services;
        }
    }
}