using Microsoft.AspNetCore.Mvc;
using System;
using Flurl.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Serilog;
using demo.api1.Code;

namespace demo.api1.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        static Guid Id = Guid.NewGuid();
        static string startTime = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm");
        IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public string Get()
        {
            string rst = $"===demo.api1" +
                $"\n\t build: {System.IO.File.GetLastWriteTime(GetType().Assembly.Location):yyyy-MM-dd HH:mm}" +
                $"\n\t run: {startTime}";

            Log.Warning(rst);
            return rst;
        }

        [HttpGet("test")]
        public async Task<string> Index()
        {
            //环境变量
            var host = Environment.GetEnvironmentVariable("NAME_API_SERVICE_HOST");
            var port = Environment.GetEnvironmentVariable("NAME_API_SERVICE_PORT");
            //自定义环境变量 取到pod name
            var name = Environment.GetEnvironmentVariable("HOSTNAME_COMMAND");

            var demoStr = $"===pod-name: {name}\n\t id: {Id} \n\t url: {host}:{port}";
            //结合Flurl，服务间调用
            var apiStr = await $"http://{_config["api-url"]}".GetStringAsync();

            return $"{Get()} \n\t {demoStr} \n\t {apiStr}";
        }

        [HttpGet("health")]
        public string Health()
        {
            Log.Information("health");
            return "running ok";
        }

        [HttpGet("400")]
        public ActionResult Bad400()
        {
            return new StatusCodeResult(StatusCodes.Status400BadRequest);
        }
        [HttpGet("401")]
        public ActionResult Bad401()
        {
            return new StatusCodeResult(StatusCodes.Status401Unauthorized);
        }
        [HttpGet("500")]
        public ActionResult Bad500()
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
        [HttpGet("random")]
        public async Task<ActionResult> Random()
        {
            int delay = new Random().Next(1000, 5000);
            await Task.Delay(delay);
            return Ok("等待时间:" + delay);
        }
        [HttpGet("error")]
        public ActionResult Error()
        {
            new ErrorTest().RunError();
            return Ok("异常测试");
        }
    }


}
