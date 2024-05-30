using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderServices, OrderService>();
            services.AddScoped<IGenericService, GenericService>();
            services.AddScoped<IUploaderService, UploaderService>();

            return services;
        }
    }
}
