using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace redis_keyvalue.Data
{
    public class RedisContext
    {
        private readonly ConnectionMultiplexer _redisConnection;

        public IDatabase RedisDb { get; }

        public RedisContext(ConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;

            RedisDb = redisConnection.GetDatabase();
        }

        // Get a single Key from Redis
        public string GetKey(string key)
        {
            return RedisDb.StringGet(key);
        }

        // Set a key in Redis
        public bool SetKey(string key, string value)
        {
            var status = RedisDb.StringSet(key, value);
            return status;
        }

        // Delete a key in Redis
        public bool DeleteKey(string key)
        {
            var status = RedisDb.KeyDelete(key);
            return status;
        }
    }
}
