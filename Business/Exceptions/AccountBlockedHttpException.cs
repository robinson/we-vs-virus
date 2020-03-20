using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class AccountBlockedHttpException : BadRequestHttpException
    {
        public AccountBlockedHttpException(string message)
           : base(message)
        {
        }

        public AccountBlockedHttpException() : base("Dieses Benutzerkonto ist gesperrt.")
        {
        }

        public AccountBlockedHttpException(Exception innerException) : base(innerException)
        {
        }
    }
}
