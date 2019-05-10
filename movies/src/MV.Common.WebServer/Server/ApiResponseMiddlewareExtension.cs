using Microsoft.AspNetCore.Builder;

namespace MV.Common.WebServer.Server
{
    public static class ApiResponseMiddlewareExtension
    {
        public static IApplicationBuilder UseApiResponseWrapperMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiResponseMiddleware>();
        }
    }
}