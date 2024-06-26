﻿using Application.Application;
using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations
{
    public static class RepositoryConfigurator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderFormRepository, OrderFormRepository>();
            services.AddScoped<IGenericRepository , GenericRepository>();
            services.AddScoped<IFileUploaderRepository, FileUploaderRepository>();
            
            return services;
        }
    }
}
