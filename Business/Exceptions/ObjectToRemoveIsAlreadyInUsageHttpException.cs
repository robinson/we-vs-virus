using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class ObjectToRemoveIsAlreadyInUsageHttpException : HttpStatusCodeException
    {
        public ObjectToRemoveIsAlreadyInUsageHttpException(string what)
           : base(StatusCodes.Status400BadRequest, new JObject { { "error", $"{what} kann nicht gelöscht werden, da diese Instanz bereits in anderen Konfigurationen oder von Benutzern verwendet wird." } })
        {
        }

        public ObjectToRemoveIsAlreadyInUsageHttpException() : base(StatusCodes.Status400BadRequest, new JObject { { "error", "Diese Instanz kann nicht gelöscht werden, da diese Instanz bereits in anderen Konfigurationen oder von Benutzern verwendet wird." } })
        {
        }

        public ObjectToRemoveIsAlreadyInUsageHttpException(Exception innerException) : base(StatusCodes.Status400BadRequest, innerException)
        {
        }
    }
}
