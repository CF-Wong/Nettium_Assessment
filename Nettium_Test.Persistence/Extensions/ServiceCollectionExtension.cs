using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nettium_Test.Application.Interfaces.Caching;
using Nettium_Test.Application.Interfaces.Messaging;
using Nettium_Test.Application.Interfaces.Repositories;
using Nettium_Test.Application.Interfaces.Repositories.Shares;
using Nettium_Test.Persistence.Caching;
using Nettium_Test.Persistence.Datas;
using Nettium_Test.Persistence.Messaging;
using Nettium_Test.Persistence.Repositories;
using Nettium_Test.Persistence.Repositories.Shares;

namespace Nettium_Test.Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddRedisCache();
            services.AddRabbitMQ();
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connString = configuration.GetConnectionString("DefaultDB");
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlite(connString);
            });
        }

        private static void AddRedisCache(this IServiceCollection services)
        {
            services.AddSingleton<IRedisCacheService, RedisCacheService>();
        }

        private static void AddRabbitMQ(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
