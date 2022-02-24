using HakerNewsIntegration.Domain.Models;
using HakerNewsIntegration.Infra.ServiceAgent.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HakerNewsIntegration.Tests.Mocks
{
    internal class ServiceAgentMock : IHackerServiceAgent
    {
        public Task<HakerAgentResponse> GetHakerAgentResponseById(long id)
        {
            return Task.FromResult(new HakerAgentResponse()
            {
                By= "Teste",
                Descendants = 1,
                Score = 100,
                Id = 1,
                Title = "Teste",
                Url = "teste.com",
                Type = "T",
                Time = 1
            });
        }

        public Task<IEnumerable<string>> GetTopItemsIds()
        {
            return Task.FromResult(new List<string>()
            {
                "1"
            } as IEnumerable<string>);
        }
    }
}
