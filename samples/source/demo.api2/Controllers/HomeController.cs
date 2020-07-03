using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace demo.api2.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        static Guid Id = Guid.NewGuid();
        ILogger<HomeController> _logger;
        static string startTime = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm");

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("this is demo.api2");

            return $"===demo.api2:" +
                $"\n\t build: {System.IO.File.GetLastWriteTime(GetType().Assembly.Location):yyyy-MM-dd HH:mm}" +
                $"\n\t run: {startTime}";
        }

        [HttpGet("health")]
        public string Health()
        {
            return "running ok";
        }
    }
}
