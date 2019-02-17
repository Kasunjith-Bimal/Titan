using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Titan.Middleware.MiddlewareModel
{
    public class NotSaveCustomException : BaseCustomException
    {
        public NotSaveCustomException(string message, string description) : base(message, description, (int)HttpStatusCode.NoContent)
        {
        }
    }
}
