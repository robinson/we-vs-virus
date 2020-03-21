using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;

namespace WeVsVirus.Business.Exceptions
{
    public class InvalidEmailAndPasswordCombinationHttpException : BadRequestHttpException
    {
        public InvalidEmailAndPasswordCombinationHttpException(string message)
           : base(message)
        {
        }

        public InvalidEmailAndPasswordCombinationHttpException() : base("Ungültige Kombination aus E-Mail-Adresse und Passwort.")
        {
        }

        public InvalidEmailAndPasswordCombinationHttpException(Exception innerException) : base(innerException)
        {
        }
    }
}
