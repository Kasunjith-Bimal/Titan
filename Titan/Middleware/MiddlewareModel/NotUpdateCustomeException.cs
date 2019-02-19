using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Titan.Middleware.MiddlewareModel
{
    public class NotUpdateCustomeException : BaseCustomException
    {
        public NotUpdateCustomeException(string message, string description) : base(message, description, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
