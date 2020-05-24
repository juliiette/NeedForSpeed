using Microsoft.Extensions.DependencyInjection;
using Data.Abstract;
using Data.Entity;
using Data.Implementation.Repositories;

namespace Data.Implementation
{
    public static class DataServices
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<NFSContext>();

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            serviceCollection.AddScoped<ICarRepository, CarRepository>();

            serviceCollection.AddScoped<IDetailRepository, DetailRepository>();

            serviceCollection.AddScoped<IPlayerRepository, PlayerRepository>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}