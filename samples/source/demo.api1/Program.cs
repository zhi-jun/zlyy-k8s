using demo.common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace demo.api1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               })
               .UseSerilog()
               .Build()
               .Run();
        }
    }
}
