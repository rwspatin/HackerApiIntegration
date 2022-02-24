using HakerNewsIntegration.Infra.Repository;
using HakerNewsIntegration.Infra.Repository.Interface;
using HakerNewsIntegration.Infra.ServiceAgent;
using HakerNewsIntegration.Infra.ServiceAgent.Interface;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace HakerNewsIntegration.Infra.IoC
{
    public static class InfraDependencyInjections
    {
        public static IServiceCollection AddInfraInjections(this IServiceCollection services)
        {
            services
                .AddHttpClient<IHackerServiceAgent, HackerServiceAgent>()
                .AddPolicyHandler(GetRetryPolicy());

            services.AddScoped<IHackerServiceAgent, HackerServiceAgent>();

            services.AddSingleton<ICacheRepository, CacheRepository>();

            services.AddMemoryCache();

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(10, retryAttempt)));
        }
    }
}
