using AutoMapper;
using Infrastrucuture.Mapper;

namespace VolvoTrucks.Api.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AutoMapperConfigurationMethod(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
