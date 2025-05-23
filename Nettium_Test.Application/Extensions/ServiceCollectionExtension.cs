using Microsoft.Extensions.DependencyInjection;
using Nettium_Test.Application.Interfaces.Services;
using Nettium_Test.Application.Services;
using System.Reflection;

namespace Nettium_Test.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddApplicationServices();
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
