using Data.Abstract;
using Data.Entity;
using Data.Implementation.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Implementation
{
    public static class DataServices
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<NFSContext>();

            serviceCollection.AddScoped(typeof(IRepository<int, Car>), typeof(Repository<int, Car>));

            serviceCollection.AddScoped(typeof(IRepository<int, Player>), typeof(Repository<int, Player>));
            
            serviceCollection.AddScoped(typeof(IRepository<int, Detail>), typeof(Repository<int, Detail>));

            serviceCollection.AddScoped<ICarRepository, CarRepository>();

            serviceCollection.AddScoped<IDetailRepository, DetailRepository>();

            serviceCollection.AddScoped<IPlayerRepository, PlayerRepository>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}