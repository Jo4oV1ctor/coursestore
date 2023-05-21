using Microsoft.Extensions.Caching.Memory;

namespace CourseStore.Repositories
{
    public static class MockRepository<T>
    {
        private static MemoryCacheOptions cacheOptions = new MemoryCacheOptions();
        public static MemoryCache cache = new MemoryCache(cacheOptions);

        public static void SetCache(string name, Object obj)
        {
            cache.Set(name, obj);
        }

        public static List<T> GetCache(string name)
        {
            if (cache.TryGetValue(name, out List<T> cachedList))
            {
                // A lista foi encontrada no cache, faça o que for necessário com ela
                return cachedList;
            }
            return null;
        }
    }
}
