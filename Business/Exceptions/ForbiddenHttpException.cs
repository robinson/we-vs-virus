using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class ForbiddenHttpException : HttpStatusCodeException
    {

        public ForbiddenHttpException(string message) : base(StatusCodes.Status403Forbidden, new JObject { { "error", message } })
        {
        }

        public ForbiddenHttpException()
           : base(StatusCodes.Status403Forbidden, new JObject { { "error", "Die angeforderte Ressource steht dir nicht zur verfügung." } })
        {
        }

        public ForbiddenHttpException(Exception innerException) : base(StatusCodes.Status403Forbidden, innerException)
        {
        }
    }
}
