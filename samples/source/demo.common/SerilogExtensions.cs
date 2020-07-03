using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Elasticsearch;

namespace demo.common
{
    public static class SerilogExtensions
    {
        public static IHostBuilder UseSerilog(this IHostBuilder builder)
        {
            return builder.UseSerilog((ctx, config) =>
            {
                config.ReadFrom.Configuration(ctx.Configuration);
                config.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error);
                config.WriteTo.Console(new ElasticsearchJsonFormatter());
            });
        }
    }
}
