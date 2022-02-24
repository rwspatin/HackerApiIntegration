using HakerNewsIntegration.Domain.Configs;
using HakerNewsIntegration.Domain.Models;
using HakerNewsIntegration.Infra.ServiceAgent.Interface;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HakerNewsIntegration.Infra.ServiceAgent
{
    internal class HackerServiceAgent : IHackerServiceAgent
    {
        private readonly HttpClient _httpClient;
        private readonly HakerAgentConfigs _hakerAgentConfigs;
        
        public HackerServiceAgent(
            IHttpClientFactory httpClientFactory,
            IOptions<HakerAgentConfigs> optionsHakerAgentConfig)
        {
            _httpClient = httpClientFactory.CreateClient();
            _hakerAgentConfigs = optionsHakerAgentConfig.Value ?? throw new ArgumentException(nameof(HakerAgentConfigs));
        }

        public async Task<HakerAgentResponse> GetHakerAgentResponseById(long id)
        {
            var url = $"{_hakerAgentConfigs.ApiUrl}{_hakerAgentConfigs.GetItem}/{id}.json";
            
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<HakerAgentResponse>(content);
        }

        public async Task<IEnumerable<string>> GetTopItemsIds()
        {
            var url = $"{_hakerAgentConfigs.ApiUrl}{_hakerAgentConfigs.AllItems}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<string>>(content);
        }
    }
}
