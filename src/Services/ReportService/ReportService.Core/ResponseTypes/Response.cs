using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Core.ResponseTypes
{
    public class Response<T> where T : class
    {
        public T Data { get; init; }
        public int StatusCode { get; init; }
        public bool IsSuccessful { get; init; }
        public List<string> Errors { get; init; } = new();

        public static Response<T> Success(T data, int statusCode, string friendlyMessage = "ActionWasSuccessful")
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(int statusCode, List<string> errors, string friendlyMessage = "ActionFailed")
        {
            return new Response<T> { StatusCode = statusCode, IsSuccessful = false, Errors = errors };
        }
    }
}
