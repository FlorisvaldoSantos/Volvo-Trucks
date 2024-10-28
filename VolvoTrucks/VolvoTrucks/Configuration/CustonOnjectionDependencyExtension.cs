using Infrastrucuture.Repository;

namespace VolvoTrucks.Configuration
{
    public static class CustonOnjectionDependencyExtension
    {
        public static void CustonOnjectionDependencyExtensionMethod(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITruckRepository, TruckRepository>();
        }
    }
}
