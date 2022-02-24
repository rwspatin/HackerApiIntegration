namespace HakerNewsIntegration.Infra.Repository.Interface
{
    public interface ICacheRepository
    {
        bool TryGet<T>(string key, out T value);
        void Set<T>(string key, T value, int minutesExpiration = 10);
    }
}
