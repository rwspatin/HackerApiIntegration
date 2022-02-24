using HakerNewsIntegration.Domain.DTOs;

namespace HakerNewsIntegration.Application.Services.Interface
{
    public interface IHackerService
    {
        Task<List<HakerHakingResponseDTO>> Get20Hanking();
    }
}
