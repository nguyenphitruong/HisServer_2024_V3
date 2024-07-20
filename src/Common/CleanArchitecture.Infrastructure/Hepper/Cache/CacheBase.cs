using System;

namespace Emr.Infrastructure.Hepper.Cache
{
    public abstract class CacheBase : ICache
    {
        public DateTimeOffset minDateTimeOffset = DateTimeOffset.MinValue;

        public abstract bool AddWithDateTimeExpiration<T>(string key, T value, DateTimeOffset absExpiration);

        public abstract bool Contains(string key);

        public abstract T GetCacheItem<T>(string key);

        public abstract void RemoveCacheItem(string key);
    }
}
