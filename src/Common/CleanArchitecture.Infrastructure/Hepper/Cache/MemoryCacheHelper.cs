using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emr.Infrastructure.Hepper.Cache
{
    public class MemoryCacheHelper : CacheBase
    {
        private static readonly Object _locker = new object();

        /// <summary>
        /// Retrieve cached items and return empty if nonexistent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public override T GetCacheItem<T>(String key)
        {
            try
            {
                return (T)MemoryCache.Default[key];
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Does it contain cached items with specified keys
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool Contains(string key)
        {
            return MemoryCache.Default.Contains(key);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absExpiration"></param>
        /// <returns></returns>
        public override bool AddWithDateTimeExpiration<T>(string key, T value, DateTimeOffset absExpiration)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
                if (absExpiration == null) throw new ArgumentException("AbsExpiration must be provided");

                if (MemoryCache.Default[key] == null)
                {
                    lock (_locker)
                    {
                        if (MemoryCache.Default[key] == null)
                        {
                            if (!typeof(T).IsValueType && ((object)value) == null) //If it is a reference type and NULL, there is no cache
                            {
                                throw new ArgumentException("Value is null");
                            }

                            var item = new CacheItem(key, value);
                            var policy = CreatePolicy(absExpiration);

                            MemoryCache.Default.Add(item, policy);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Remove cached entries for specified keys
        /// </summary>
        /// <param name="key"></param>
        public override void RemoveCacheItem(string key)
        {
            try
            {
                MemoryCache.Default.Remove(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CacheItemPolicy CreatePolicy(DateTimeOffset absExpiration)
        {
            var policy = new CacheItemPolicy();

            try
            {
                if (absExpiration != null && absExpiration != minDateTimeOffset)
                {
                    policy.AbsoluteExpiration = absExpiration;
                    policy.Priority = CacheItemPriority.Default;
                }
                else //khong bao gio xoa cache
                {
                    policy.Priority = CacheItemPriority.NotRemovable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return policy;
        }
    }
}
