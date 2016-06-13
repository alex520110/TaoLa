using Autofac;
using Autofac.Builder;
using Autofac.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public static class Cache
    {
        private static object cacheLocker;

        private static ICache cache;

        public static int TimeOut
        {
            get
            {
                return Cache.cache.TimeOut;
            }
            set
            {
                lock (Cache.cacheLocker)
                {
                    Cache.cache.TimeOut = value;
                }
            }
        }

        static Cache()
        {
            Cache.cacheLocker = new object();
            Cache.cache = null;
            Cache.Load();
        }

        private static void Load()
        {
            try
            {
                Cache.cache = new AspNetCache();
            }
            catch (System.Exception inner)
            {
                throw new CacheRegisterException("注册缓存服务异常", inner);
            }
        }

        public static object Get(string key)
        {
            object result;
            if (string.IsNullOrWhiteSpace(key))
            {
                result = null;
            }
            else
            {
                result = Cache.cache.Get(key);
            }
            return result;
        }

        public static void Insert(string key, object data)
        {
            if (!string.IsNullOrWhiteSpace(key) && data != null)
            {
                lock (Cache.cacheLocker)
                {
                    Cache.cache.Insert(key, data);
                }
            }
        }

        public static void Insert(string key, object data, int cacheTime)
        {
            if (!string.IsNullOrWhiteSpace(key) && data != null)
            {
                lock (Cache.cacheLocker)
                {
                    Cache.cache.Insert(key, data, cacheTime);
                }
            }
        }

        public static void Insert(string key, object data, System.DateTime cacheTime)
        {
            if (!string.IsNullOrWhiteSpace(key) && data != null)
            {
                lock (Cache.cacheLocker)
                {
                    Cache.cache.Insert(key, data, cacheTime);
                }
            }
        }

        public static void Remove(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                lock (Cache.cacheLocker)
                {
                    Cache.cache.Remove(key);
                }
            }
        }
    }
}
