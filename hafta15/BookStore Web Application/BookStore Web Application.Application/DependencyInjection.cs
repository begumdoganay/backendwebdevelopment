using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookStore_Web_Application.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            IServiceCollection serviceCollection = services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}