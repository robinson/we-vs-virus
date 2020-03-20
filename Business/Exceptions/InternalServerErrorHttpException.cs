using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class InternalServerErrorHttpException : HttpStatusCodeException
    {
        public InternalServerErrorHttpException(string message)
           : base(StatusCodes.Status500InternalServerError, new JObject { { "error", message } })
        {
        }

        public InternalServerErrorHttpException() : base(StatusCodes.Status500InternalServerError, new JObject { { "error", "Interner Serverfehler. Bitte melden Sie diesen Fehler beim Support." } })
        {
        }

        public InternalServerErrorHttpException(Exception innerException) : base(StatusCodes.Status500InternalServerError, innerException)
        {
        }
    }
}
