using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class RepositoryConfigurator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IRepository, Repository>();
            return services;
        }
    }
}
