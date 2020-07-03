using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace demo.common
{
    /// <summary>
    /// 统一错误处理
    /// </summary>
    public class GlobalMiddleware
    {
        private readonly RequestDelegate _next;
        ILogger<GlobalMiddleware> _config;

        /// <summary>
        /// DI,注入环境变量
        /// </summary>
        /// <param name="next"></param>
        /// <param name="environment"></param>
        public GlobalMiddleware(RequestDelegate next, ILogger<GlobalMiddleware> _config)
        {
            _next = next;
        }
        /// <summary>
        /// 实现Invoke方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        /// <summary>
        /// 错误信息处理方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string errorMsg = $"{ex.Message} \r\n【StackTrace】：{ex.StackTrace}";

            //记录日志
            _config.LogError(errorMsg);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; ;
            context.Response.ContentType = "application/json";

            //返回错误信息
            return context.Response.WriteAsync(errorMsg);
        }
    }
}
