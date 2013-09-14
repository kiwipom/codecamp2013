namespace Funcy
{
    public interface ICacheService
    {
        T Get<T>(string key);

        void Add<T>(string key, T value);
    }
}