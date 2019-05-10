using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MV.Common.WebServer.Server
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly UserContext user;

        public ApiResponseMiddleware(RequestDelegate next, UserContext user)
        {
            this.next = next;
            this.user = user;
        }

        public async Task Invoke(HttpContext context)
        {
            if (IsSwagger(context) || IsDownload(context) || context.Request.Method == HttpMethods.Options)
            {
                await next(context);
            }
            else
            {
                var headerUserId = context.Request.Headers["UserId"].FirstOrDefault();

                if (headerUserId != null) user.Id = Guid.Parse(headerUserId);

                var originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    try
                    {
                        await next.Invoke(context);
                        await HandleRequestAsync(context);
                    }
                    catch (Exception ex)
                    {
                        await HandleRequestAsync(context, ex);
                    }
                    finally
                    {
                        responseBody.Seek(0, SeekOrigin.Begin);
                        await responseBody.CopyToAsync(originalBodyStream);
                    }
                }
            }
        }

        private async Task HandleRequestAsync(HttpContext context)
        {
            var body = await FormatResponse(context.Response);
            switch (context.Response.StatusCode)
            {
                case (int) HttpStatusCode.OK:
                    await HandleRequestAsync(context, body, ResponseMessage.Success);
                    break;
                case (int) HttpStatusCode.Unauthorized:
                    await HandleRequestAsync(context, body, ResponseMessage.UnAuthorized);
                    break;
                default:
                    await HandleRequestAsync(context, body, ResponseMessage.Failure);
                    break;
            }
        }

        private Task HandleRequestAsync(HttpContext context, Exception exception)
        {
            ApiError apiError;
            var code = 0;

            switch (exception)
            {
                case ApiException ex:
                    apiError = new ApiError(ex.Message)
                    {
                        ValidationErrors = ex.Errors,
                        ReferenceErrorCode = ex.ReferenceErrorCode,
                        ReferenceDocumentLink = ex.ReferenceDocumentLink
                    };
                    code = ex.StatusCode;
                    context.Response.StatusCode = code;
                    break;
                case UnauthorizedAccessException _:
                    apiError = new ApiError("Unauthorized Access");
                    code = (int) HttpStatusCode.Unauthorized;
                    context.Response.StatusCode = code;
                    break;
                default:
                    var msg = exception.GetBaseException().Message;
                    var stack = exception.StackTrace;

                    apiError = new ApiError(msg) {Details = stack};
                    code = (int) HttpStatusCode.InternalServerError;
                    context.Response.StatusCode = code;
                    break;
            }

            return HandleRequestAsync(context, null, ResponseMessage.Exception, apiError);
        }

        private Task HandleRequestAsync(HttpContext context, object body, ResponseMessage message,
            ApiError apiError = null)
        {
            var code = context.Response.StatusCode;
            context.Response.ContentType = "application/json";

            var bodyText = string.Empty;

            if (body != null)
                bodyText = !body.ToString().IsValidJson() ? JsonConvert.SerializeObject(body) : body.ToString();

            var bodyContent = JsonConvert.DeserializeObject<dynamic>(bodyText);
            var apiResponse = new ApiResponse(code, message.GetDescription(), bodyContent, apiError);
            var jsonString = JsonConvert.SerializeObject(apiResponse) ??
                             throw new ArgumentNullException("JsonConvert.SerializeObject(apiResponse)");

            return context.Response.WriteAsync(jsonString);
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var plainBodyText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return plainBodyText.Replace("\"", "'");
        }

        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");
        }
    }
}