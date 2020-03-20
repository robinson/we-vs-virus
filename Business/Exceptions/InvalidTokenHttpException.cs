using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class InvalidTokenHttpException : HttpStatusCodeException
    {
        public InvalidTokenHttpException(string message)
           : base(StatusCodes.Status400BadRequest, new JObject { { "error", message } })
        {
        }

        public InvalidTokenHttpException() : base(StatusCodes.Status400BadRequest, new JObject { { "error", "Das Token war ungültig." } })
        {
        }

        public InvalidTokenHttpException(Exception innerException) : base(StatusCodes.Status400BadRequest, innerException)
        {
        }
    }
}
