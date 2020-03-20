using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class ObjectAlreadyExistsHttpException : HttpStatusCodeException
    {
        public ObjectAlreadyExistsHttpException(string what)
           : base(StatusCodes.Status400BadRequest, new JObject { { "error", $"{what} existiert bereits." } })
        {
        }

        public ObjectAlreadyExistsHttpException() : base(StatusCodes.Status400BadRequest, new JObject { { "error", "Diese Instanz existiert bereits." } })
        {
        }

        public ObjectAlreadyExistsHttpException(Exception innerException) : base(StatusCodes.Status400BadRequest, innerException)
        {
        }
    }
}
