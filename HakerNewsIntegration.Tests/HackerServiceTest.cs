using AutoMapper;
using HakerNewsIntegration.Application.MapperProfile;
using HakerNewsIntegration.Application.Services;
using HakerNewsIntegration.Application.Services.Interface;
using HakerNewsIntegration.Infra.Repository.Interface;
using HakerNewsIntegration.Infra.ServiceAgent.Interface;
using HakerNewsIntegration.Tests.Mocks;
using Xunit;

namespace HakerNewsIntegration.Tests
{
    public class HackerServiceTest
    {
        private readonly IHackerService _hackerService = new HackerService(new ServiceAgentMock(), new CacheRepositoryMock(), new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new HackProfile());
        }).CreateMapper());

        [Fact]
        public void MustReturnAListOfHackers()
        {
            var services = _hackerService.Get20Hanking().Result;

            Assert.True(services.Count >= 1);
        }
    }
}