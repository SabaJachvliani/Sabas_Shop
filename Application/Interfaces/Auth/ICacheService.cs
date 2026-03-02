namespace Application.Interfaces.Auth
{
    public interface ICacheService
    {
        Task<T> GetOrCreateAsync<T>(
            string key,
            TimeSpan ttl,
            Func<CancellationToken, Task<T>> factory,
            CancellationToken ct);

        void Remove(string key);
    }
}
