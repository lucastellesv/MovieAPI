using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class ResponseModel
    {
        public ResponseModel(int statusCode)
        {
            StatusCode = statusCode;
        }

        public ResponseModel(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
