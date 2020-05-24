using Data.Abstract;
using Data.Implementation.Repositories;
using Microsoft.Extensions.DependencyInjection;

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