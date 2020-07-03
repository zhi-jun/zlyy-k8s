using Microsoft.AspNetCore.Mvc;
using System;

namespace demo.identity.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        static string runTime = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm");

        [HttpGet]
        public IActionResult Home()
        {
            string rst = $"build: {System.IO.File.GetLastWriteTime(GetType().Assembly.Location):yyyy-MM-dd HH:mm}" +
                        $"\n\t run: {runTime}";
            return Ok(rst);
        }
    }
}
