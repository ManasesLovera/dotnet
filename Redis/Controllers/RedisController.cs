using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redis.Intefaces;

namespace Redis.Controllers
{
    /// <summary>
    /// API Controller for interacting with Redis.
    /// Provides endpoints for setting and retrieving key-value pairs.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RedisController : ControllerBase
    {
        private readonly IRedisService _redisService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisController"/> class.
        /// </summary>
        /// <param name="redisService">The Redis service instance.</param>
        public RedisController(IRedisService redisService)
        {
            _redisService = redisService;
        }

        /// <summary>
        /// Sets a key-value pair in Redis.
        /// </summary>
        /// <param name="key">The key to store the value under.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>An <see cref="IActionResult"/> indicating success.</returns>
        [HttpPost("set")]
        public IActionResult Set(string key, string value) {
            _redisService.SetValue(key, value);
            return Ok($"Key {key} set successfully");
        }

        /// <summary>
        /// Retrieves a value from Redis using the specified key.
        /// </summary>
        /// <param name="key">The key to retrieve the value from.</param>
        /// <returns>An <see cref="IActionResult"/> containing the value if found, or a NotFound response if the key does not exist.</returns>
        [HttpGet("get")]
        public IActionResult Get(string key) {
            var value = _redisService.GetValue(key);
            if (value == null) {
                return NotFound();
            }
            return Ok(value);
        }

        /// <summary>
        /// Publish message string to a channel using Redis.
        /// </summary>
        /// <param name="channel">The channel to publish.</param>
        /// <param name="message">The message that will be published.</param>
        /// <returns>Accepted 202 status code indicating the request has been received and working on it.</returns>
        [HttpPost("publish")]
        public IActionResult Publish([FromQuery] string channel, [FromQuery] string message)
        {
            _redisService.PublishMessage(channel, message);
            return Accepted($"Published message to {channel}: {message}");
        }
    }
}