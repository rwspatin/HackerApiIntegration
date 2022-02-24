using HakerNewsIntegration.Infra.Repository.Interface;

namespace HakerNewsIntegration.Tests.Mocks
{
    internal class CacheRepositoryMock : ICacheRepository
    {
        public void Set<T>(string key, T value, int minutesExpiration = 10)
        {
            return;
        }

        public bool TryGet<T>(string key, out T value)
        {
            value = default(T);
            return false;
        }
    }
}
