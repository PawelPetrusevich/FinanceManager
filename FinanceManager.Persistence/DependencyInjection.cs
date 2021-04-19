using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Data.Context;
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
                options.UseSqlServer(configuration.GetConnectionString("FinanceManagerConnection")));

            services.AddScoped<IFinanceManagerContext>(provider => provider.GetService<FinanceManagerContext>());

            return services;
        }
    }
}