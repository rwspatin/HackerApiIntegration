using HakerNewsIntegration.Application.Services;
using HakerNewsIntegration.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace HakerNewsIntegration.Application.IoC
{
    public static class ApplicationInjection
    {
        public static IServiceCollection AddApplicationInjections(this IServiceCollection services)
        {
            return services
                .AddScoped<IHackerService, HackerService>()
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
