using System;

namespace WeVsVirus.Business.Exceptions
{
    public class CreateNewUserException : InternalServerErrorHttpException
    {
        public CreateNewUserException(string message)
           : base(message)
        {
        }

        public CreateNewUserException() : base("Fehler beim Erstellen eines neuen Users.")
        {
        }

        public CreateNewUserException(Exception innerException) : base(innerException)
        {
        }
    }
}
