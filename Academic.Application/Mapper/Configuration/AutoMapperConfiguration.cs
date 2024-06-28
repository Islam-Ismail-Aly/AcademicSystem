using Academic.Application.Mapper.Profiles.Account;
using Microsoft.Extensions.DependencyInjection;

namespace Academic.Application.Mapper.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration), typeof(UserMappingProfile));
        }
    }
}
