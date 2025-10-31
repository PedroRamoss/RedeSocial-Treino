using Microsoft.Extensions.DependencyInjection;
using RedeSocial.Application.Services;
using RedeSocial.Application.Services.Interfaces;

namespace RedeSocial.Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
