using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Core.ResponseTypes
{
    public class Response<T> where T : class
    {
        public T Data { get; private init; }
        public int StatusCode { get; private init; }
        public bool IsSuccessful { get; private init; }
        public List<string> Errors { get; private init; } = new();

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
