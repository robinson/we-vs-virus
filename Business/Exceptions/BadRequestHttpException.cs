using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class BadRequestHttpException : HttpStatusCodeException
    {
        public BadRequestHttpException(string message)
           : base(StatusCodes.Status400BadRequest, new JObject { { "error", message } })
        {
        }

        public BadRequestHttpException() : base(StatusCodes.Status400BadRequest, new JObject { { "error", "Eingabedaten sind ungültig." } })
        {
        }

        public BadRequestHttpException(Exception innerException) : base(StatusCodes.Status400BadRequest, innerException)
        {
        }
    }
}
