using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderFormService, OrderFormService>();
            services.AddScoped<IGenericService, GenericService>();
            services.AddScoped<IFileUploaderService, FileUploaderService>();

            return services;
        }
    }
}
