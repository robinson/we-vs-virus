using System;

namespace WeVsVirus.Business.Exceptions
{
    public class UserNameAlreadyTakenException : CreateNewUserException
    {
        private const string defaultMessage = "Ein Nutzer ist bereits mit dieser E-Mail-Adresse registriert.";

        public UserNameAlreadyTakenException(string message)
           : base(message ?? defaultMessage)
        {
        }

        public UserNameAlreadyTakenException() : base(message: defaultMessage)
        {
        }

        public UserNameAlreadyTakenException(Exception innerException) : base(innerException)
        {
        }
    }
}
