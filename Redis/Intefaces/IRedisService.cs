using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis.Intefaces
{
    public interface IRedisService
    {
        public void SetValue(string key, string value);
        public string? GetValue(string key);
        public void PublishMessage(string channel, string message);
        public void SubscribeToChannel(string channel, Action<string> handler);
    }
}