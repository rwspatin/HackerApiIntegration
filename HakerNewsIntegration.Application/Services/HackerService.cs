using AutoMapper;
using HakerNewsIntegration.Application.Services.Interface;
using HakerNewsIntegration.Domain.DTOs;
using HakerNewsIntegration.Infra.Repository.Interface;
using HakerNewsIntegration.Infra.ServiceAgent.Interface;
using System.Collections.Concurrent;

namespace HakerNewsIntegration.Application.Services
{
    public class HackerService : IHackerService
    {
        private readonly IHackerServiceAgent _hackerServiceAgent;
        private readonly ICacheRepository _cacheRepository;
        private readonly IMapper _mapper;
        private const string HACKING_KEY = "TOP_HACKINGS";

        public HackerService(IHackerServiceAgent hackerServiceAgent, ICacheRepository cacheRepository, IMapper mapper)
        {
            _hackerServiceAgent = hackerServiceAgent;
            _cacheRepository = cacheRepository;
            _mapper = mapper;
        }

        public async Task<List<HakerHakingResponseDTO>> Get20Hanking()
        {
            var hackings = await GetHackingsWithCache();

            return hackings.OrderBy(x => x.Score).Take(20).ToList();
        }

        private async Task<List<HakerHakingResponseDTO>> GetHackingsWithCache()
        {
            if(_cacheRepository.TryGet<List<HakerHakingResponseDTO>>(HACKING_KEY, out var hackings))
                return hackings;

            hackings = await GetHackings();
            _cacheRepository.Set(HACKING_KEY, hackings);

            return hackings;
        }

        private async Task<List<HakerHakingResponseDTO>> GetHackings()
        {
            var hackings = new ConcurrentBag<HakerHakingResponseDTO>();
            var topItems = await _hackerServiceAgent.GetTopItemsIds();

            await Parallel.ForEachAsync(topItems,
                parallelOptions: new() { MaxDegreeOfParallelism = 4 },
                async (item, y) =>
            {
                var hack = await _hackerServiceAgent.GetHakerAgentResponseById(long.Parse(item));

                if (hack != null)
                    hackings.Add(_mapper.Map<HakerHakingResponseDTO>(hack));
            });

            return hackings.ToList();
        }
    }
}
