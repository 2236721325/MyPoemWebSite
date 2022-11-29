using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPoem.Domain.Shared
{
    public class ApiResult<T>
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
        public T? Result { get; set; }
    }
    public class ApiResult
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
        //public object? Result { get; set; }
        public static ApiResult<T> Ok<T>(T result,string? message=null)
        {
            return new ApiResult<T>()
            {
                Status = true,
                Message = message,
                Result = result
            };
        }
        public static ApiResult<T> OhNo<T>(string? message)
        {
            return new ApiResult<T>()
            {
                Status = false,
                Message = message,
            };
        }
        public static ApiResult OhNo(string? message)
        {
            return new ApiResult()
            {
                Status = false,
                Message = message,
            };
        }
        public static ApiResult Ok(string? message=null)
        {
            return new ApiResult()
            {
                Status = true,
                Message = message,
            };
        }
    }
}
