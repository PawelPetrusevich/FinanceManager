using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(Assembly.GetExecutingAssembly());
            return service;
        }
    }
}