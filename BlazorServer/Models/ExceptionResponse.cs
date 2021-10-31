using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlazorServer.Models
{
    public class ExceptionResponse
    {
        public HttpStatusCode statusCode { get; set; }

        public string message { get; set; }

        public object modelValidationErrors { get; set; }

        public object errorDetails { get; set; }

        public object data { get; set; }
    }



    public class BaseResponse
    {
        public bool isSuccess {get;set;}
        public string message { get; set; }

        public object data { get; set; }

        public List<string> errorDetails { get; set; } = new List<string>();
    }

    public class BaseResponseError : BaseResponse
    {

        public BaseResponseError(string message)
        {
            this.message = message;
            this.isSuccess = false;
        }
    }

    public class BaseResponseSuccess<T> : BaseResponse
    {
        public T model { get; set; }

        public BaseResponseSuccess(T model)
        {
            this.isSuccess = true;
            this.message = "success";
            this.model = model;
        }

        public BaseResponseSuccess(T model,object data)
        {
            this.isSuccess = true;
            this.message = "success";
            this.model = model;
            this.data = data;
        }
    }
}
