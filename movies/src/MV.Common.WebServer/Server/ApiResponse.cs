﻿using System.Runtime.Serialization;

namespace MV.Common.WebServer.Server
{
    [DataContract]
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = "", object result = null, ApiError apiError = null)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
            ResponseException = apiError;
        }

        [DataMember] public int StatusCode { get; set; }

        [DataMember] public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)] public ApiError ResponseException { get; set; }

        [DataMember(EmitDefaultValue = false)] public object Result { get; set; }
    }
}