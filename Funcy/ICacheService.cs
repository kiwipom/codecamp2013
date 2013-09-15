using System;

namespace Funcy
{
    public interface ICacheService
    {
        T Get<T>(string key);

        void Add<T>(string key, T value);
    }

    public static class FuncyExtensions
    {
        public static T Fetch<T>(this ICacheService cacheService, string cacheKey,
            Func<T> getData)
            where T : class
        {
            // use a cache key
            var result = cacheService.Get<T>(cacheKey);

            if (result == null)
            {
                // get the data
                result = getData();
                cacheService.Add(cacheKey, result);
            }
            return result;
        }


        public static Func<TKey, TResult> Encachify<TKey, TResult>(
            this ICacheService cacheService,
            Func<TKey, string> makeCacheKey,
            Func<TKey, TResult> getData) where TResult : class
        {
            return key =>
                {
                    var cacheKey = makeCacheKey(key);
                    return cacheService
                        .Fetch(cacheKey, () => getData(key));
                };
        }

    }
}