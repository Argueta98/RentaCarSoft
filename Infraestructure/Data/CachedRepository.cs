﻿using ApplicationCore.Interfaces;
using Ardalis.Specification;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    /// <inheritdoc/>
    public class CachedRepository<T> : IReadRepository<T> where T : class
    {
        private readonly IMemoryCache _cache;
        private readonly IAppLogger<CachedRepository<T>> _logger;
        private readonly MyRepository<T> _sourceRepository;
        private MemoryCacheEntryOptions _cacheOptions;

        public CachedRepository(IMemoryCache cache,
            IAppLogger<CachedRepository<T>> logger,
            MyRepository<T> sourceRepository)
        {
            _cache = cache;
            _logger = logger;
            _sourceRepository = sourceRepository;

            _cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(10));
        }

        /// <inheritdoc/>
        public Task<int> CountAsync(ISpecification<T> specification)
        {
            // TODO: Add Caching
            return _sourceRepository.CountAsync(specification);
        }

        /// <inheritdoc/>
        public Task<T> GetByIdAsync(int id)
        {
            return _sourceRepository.GetByIdAsync(id);
        }

        /// <inheritdoc/>
        public Task<T> GetByIdAsync<TId>(TId id)
        {
            return _sourceRepository.GetByIdAsync(id);
        }

        /// <inheritdoc/>
        public Task<T> GetBySpecAsync<Spec>(Spec specification) where Spec : ISingleResultSpecification, ISpecification<T>
        {
            if (specification.CacheEnabled)
            {
                string key = $"{specification.CacheKey}-GetBySpecAsync";
                _logger.LogInformation("Checking cache for " + key);
                return _cache.GetOrCreate(key, entry =>
                {
                    entry.SetOptions(_cacheOptions);
                    _logger.LogWarning("Fetching source data for " + key);
                    return _sourceRepository.GetBySpecAsync(specification);
                });
            }
            return _sourceRepository.GetBySpecAsync(specification);
        }

        /// <inheritdoc/>
        public Task<TResult> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<List<T>> ListAsync()
        {
            string key = $"{nameof(T)}-ListAsync";
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                return _sourceRepository.ListAsync();
            });
        }

        /// <inheritdoc/>
        public Task<List<T>> ListAsync(ISpecification<T> specification)
        {
            if (specification.CacheEnabled)
            {
                string key = $"{specification.CacheKey}-ListAsync";
                _logger.LogInformation("Checking cache for " + key);
                return _cache.GetOrCreate(key, entry =>
                {
                    entry.SetOptions(_cacheOptions);
                    _logger.LogWarning("Fetching source data for " + key);
                    return _sourceRepository.ListAsync(specification);
                });
            }
            return _sourceRepository.ListAsync(specification);
        }

        /// <inheritdoc/>
        public Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification)
        {
            throw new NotImplementedException();
        }
    }
}
