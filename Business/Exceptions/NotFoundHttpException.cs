using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class NotFoundHttpException : HttpStatusCodeException
    {

        public NotFoundHttpException(string what) : base(StatusCodes.Status404NotFound, new JObject { { "error", $"{what} existiert nicht." } })
        {
        }

        public NotFoundHttpException()
           : base(StatusCodes.Status404NotFound, new JObject { { "error", "Die angeforderte Ressource existiert nicht." } })
        {
        }

        public NotFoundHttpException(Exception innerException) : base(StatusCodes.Status404NotFound, innerException)
        {
        }
    }
}
