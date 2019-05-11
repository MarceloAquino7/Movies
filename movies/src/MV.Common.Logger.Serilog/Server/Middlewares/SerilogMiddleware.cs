using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;

namespace MV.Common.Logger.Serilog.Server.Middlewares
{
    public class SerilogMiddleware : IServerMiddleware
    {
        private const string MessageTemplate =
            "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

        private readonly HashSet<string> headerWhitelist = new HashSet<string> {"User-Agent"};

        private readonly ILogger log = Log.ForContext<SerilogMiddleware>();
        private readonly RequestDelegate next;

        public SerilogMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            if (IsSwagger(context) || context.Request.Method == HttpMethods.Options)
            {
                await next(context);
            }
            else
            {
                var start = Stopwatch.GetTimestamp();

                try
                {
                    await next(context);

                    var elapsedMs = GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());

                    var statusCode = context.Response?.StatusCode;

                    var level = statusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;

                    var logger = level == LogEventLevel.Error ? LogForErrorContext(context) : log;

                    logger.Write(
                        level,
                        MessageTemplate,
                        context.Request.Method,
                        context.Request.GetPath(),
                        statusCode,
                        elapsedMs);
                }
                catch (Exception ex)
                {
                    LogException(
                        context,
                        GetElapsedMilliseconds(start, Stopwatch.GetTimestamp()),
                        ex);
                }
            }
        }

        public bool LogException(HttpContext httpContext, double elapsedMs, Exception ex)
        {
            LogForErrorContext(httpContext)
                .Error(ex,
                    MessageTemplate,
                    httpContext.Request.Method,
                    httpContext.Request.GetPath(),
                    500,
                    elapsedMs);

            return false;
        }

        public ILogger LogForErrorContext(HttpContext httpContext)
        {
            var request = httpContext.Request;

            var loggedHeaders = request.Headers
                .Where(item => headerWhitelist.Contains(item.Key))
                .ToDictionary(item => item.Key,
                    item => item.Value.ToString());

            var result = log
                .ForContext("RequestHeaders", loggedHeaders, true)
                .ForContext("RequestHost", request.Host)
                .ForContext("RequestProtocol", request.Protocol);

            return result;
        }

        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");
        }

        public double GetElapsedMilliseconds(long start, long stop)
        {
            return (stop - start) * 1000 / (double) Stopwatch.Frequency;
        }
    }
}