﻿using System.Collections.Generic;

namespace Core.Common.Core
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
            ValidationErrors = new List<string>();
            Message = string.Empty;
        }

        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}