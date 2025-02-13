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
    }
}