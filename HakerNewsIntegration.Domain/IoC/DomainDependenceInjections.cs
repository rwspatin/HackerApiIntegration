using HakerNewsIntegration.Domain.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HakerNewsIntegration.Domain.IoC
{
    public static class DomainDependenceInjections
    {
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                    .Configure<HakerAgentConfigs>(configuration.GetSection("HakerAgent"));
        }
    }
}
