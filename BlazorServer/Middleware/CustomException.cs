using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Middleware
{
    public class UnauthorizedException : System.Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
    public class BadRequestException : System.Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
