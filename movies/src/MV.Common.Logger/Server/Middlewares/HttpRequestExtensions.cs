﻿using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace MV.Common.Logger.Server.Middlewares
{
    public static class HttpRequestExtensions
    {
        public static string GetRawBodyString(this HttpRequest request, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            using (var reader = new StreamReader(request.Body, encoding))
            {
                return reader.ReadToEnd();
            }
        }

        public static byte[] GetRawBodyBytes(this HttpRequest request)
        {
            using (var ms = new MemoryStream(2048))
            {
                request.Body.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static string GetPath(this HttpRequest request)
        {
            return request
                       .HttpContext
                       .Features
                       .Get<IHttpRequestFeature>()?.RawTarget ??
                   request.HttpContext.Request.Path.ToString();
        }
    }
}