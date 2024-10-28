using Infrastrucuture.Context;
using VolvoTrucks.Api.Services;

namespace VolvoTrucks.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void ServiceCollectionExtensionsMethod(this IServiceCollection services) 
        {
            services.AddDbContext<VolvoTruckContext>();

            services.AddScoped<ITruckService, TruckService>();
        }
    }
}
