using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redis.Intefaces;
using StackExchange.Redis;

namespace Redis.Services
{
    /// <summary>
    /// Provides methods for interacting with Redis, including setting and getting values.
    /// </summary>
    public class RedisService : IRedisService
    {
        private readonly IDatabase _db;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisService"/> class.
        /// </summary>
        /// <param name="logger">The logger for logging Redis interactions.</param>
        public RedisService(ILogger<RedisService> logger)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            _db = redis.GetDatabase();
            _logger = logger;
        }

        /// <summary>
        /// Sets a value in Redis with a key that expires in 10 minutes.
        /// </summary>
        /// <param name="key">The Redis key.</param>
        /// <param name="value">The value to store.</param>
        public void SetValue(string key, string value) {
            _db.StringSet(key, value, TimeSpan.FromMinutes(10)); // Key expires in 10 min
            _logger.LogInformation("Redis SET: {Key} = {Value}", key, value);
        }

        /// <summary>
        /// Retrieves a value from Redis using the specified key.
        /// </summary>
        /// <param name="key">The Redis key.</param>
        /// <returns>The stored value, or <c>null</c> if the key is not found.</returns>
        public string? GetValue(string key) {
            var value = _db.StringGet(key);
            if (value.IsNullOrEmpty) {
                _logger.LogWarning("Redis GET: Key {Key} not found", key);
                return null;
            }

            _logger.LogInformation("Redis GET: {Key} = {Value}", key, value);
            return value;
        }
    }
}