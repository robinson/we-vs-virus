using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WeVsVirus.Business.Utility
{
    public static class CustomValidationAttribute
    {
        public sealed class CheckString : ValidationAttribute
        {
            public string[] AllowedStrings { get; set; }

            protected override ValidationResult IsValid(object stringValue, ValidationContext validationContext)
            {
                if (AllowedStrings.Contains(stringValue))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

        }

    }
}