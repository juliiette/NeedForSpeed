using Microsoft.Extensions.DependencyInjection;
using Data.Abstract;
using Data.Entity;

namespace Data.Implementation
{
    public static class DataServices
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<NFSContext>();

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}