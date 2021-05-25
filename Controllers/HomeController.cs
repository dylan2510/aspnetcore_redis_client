using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using redis_keyvalue.Data;
using redis_keyvalue.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace redis_keyvalue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RedisContext _redis;

        public HomeController(ILogger<HomeController> logger, RedisContext redis)
        {
            _logger = logger;
            _redis = redis;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetKeys()
        {
            // set some keys
            _redis.SetKey("name", "dylan");
            _redis.SetKey("age", "Always 20");

            return Content("setting some keys..");
        }

        public IActionResult GetKeys()
        {
            var value = _redis.GetKey("name");
            return Content($"value of key = {value}");
        }

    }
}
