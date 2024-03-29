﻿namespace Services.HandleResponse
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int code)
            => code switch
            {
                400 => "Bad Request",
                401 => "You Are Npt Authorized",
                404 => "Resource Not Found",
                500 => "Internal Server Error",
                _ => null
            };


    }
}
