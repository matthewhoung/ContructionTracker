﻿using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderServices, OrderService>();

            return services;
        }
    }
}
