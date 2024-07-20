using System;

namespace Emr.Infrastructure.Hepper.Cache
{
    public interface ICache
    {
        T GetCacheItem<T>(String key);

        bool Contains(string key);

        bool AddWithDateTimeExpiration<T>(string key, T value, DateTimeOffset absExpiration);

        void RemoveCacheItem(string key);
    }
}
