using System;
using EPiServer.Core;
using EPiServer.Framework.Cache;

namespace High.Net.Core.Caching
{
	public interface ICache
	{
		T Get<T>(string key);
		void Add<T>(T objectToCache, string key, TimeSpan offset);
		void Remove(string key);
		bool Exists(string key);
		void Clear();
	}

	public class EPiServerCache : ICache
	{
		private readonly string[] _cacheDependencyKeys;
		private readonly ISynchronizedObjectInstanceCache _objectInstanceCache;

		public EPiServerCache(ISynchronizedObjectInstanceCache objectInstanceCache, IContentCacheKeyCreator cacheKeyCreator)
		{
			_cacheDependencyKeys = new[] { cacheKeyCreator.VersionKey };
			_objectInstanceCache = objectInstanceCache;
		}

		public T Get<T>(string key)
		{
			T cacheItem;

			try
			{
				cacheItem = (T)_objectInstanceCache.Get(key);
			}
			catch (Exception)
			{
				cacheItem = default(T);
			}

			return cacheItem;
		}


		public void Add<T>(T objectToCache, string key, TimeSpan expiration)
		{
			var evictionPolicy = new CacheEvictionPolicy(expiration, CacheTimeoutType.Absolute, _cacheDependencyKeys);
			_objectInstanceCache.Insert(key, objectToCache, evictionPolicy);
		}

		public bool Exists(string key)
		{
			return (_objectInstanceCache.Get(key) != null);
		}

		public void Clear()
		{
			_objectInstanceCache.Clear();
		}

		public void Remove(string key)
		{
			_objectInstanceCache.Remove(key);
		}
	}
}
