using HakerNewsIntegration.Application.Services.Interface;
using HakerNewsIntegration.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HakerNewsIntegration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HackerHankingController : ControllerBase
    {
        private readonly IHackerService _hackerService;

        public HackerHankingController(IHackerService hackerService)
        {
            _hackerService = hackerService;
        }

        [HttpGet(Name = "GetTop20Hacking")]
        public async Task<List<HakerHakingResponseDTO>> GetTop20Hacking()
        {
            return await _hackerService.Get20Hanking();
        }
    }
}