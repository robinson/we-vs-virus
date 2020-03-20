using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class AccountLockedHttpException : HttpStatusCodeException
    {
        public AccountLockedHttpException(string message)
           : base(StatusCodes.Status423Locked, new JObject { { "error", message } })
        {
        }

        public AccountLockedHttpException() : base(StatusCodes.Status423Locked, new JObject { { "Account wurde gespert." } })
        {
        }

        public AccountLockedHttpException(Exception innerException) : base(StatusCodes.Status423Locked, innerException)
        {
        }
    }
}
