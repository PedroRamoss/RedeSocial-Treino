using Microsoft.Extensions.DependencyInjection;
using RedeSocial.Database.Configuration;
using RedeSocial.Database.Repositories;
using RedeSocial.Domain.Interfaces.Repositories;

namespace RedeSocial.Database
{
    public static class DatabaseModuleDependency
    {
        public static void AddRepositoriesDependency(this IServiceCollection services)
        {
            services.AddScoped<DatabaseConnection>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
        }
    }
}
