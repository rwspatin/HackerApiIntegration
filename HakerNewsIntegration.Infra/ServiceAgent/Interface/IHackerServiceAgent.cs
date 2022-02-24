using HakerNewsIntegration.Domain.Models;

namespace HakerNewsIntegration.Infra.ServiceAgent.Interface
{
    public interface IHackerServiceAgent
    {
        Task<IEnumerable<string>> GetTopItemsIds();
        Task<HakerAgentResponse> GetHakerAgentResponseById(long id);
    }
}
