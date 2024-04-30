using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApi.Validations
{
    public class FechaMayorQueHoyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var fecha = (DateTime)value;

            if (fecha <= DateTime.Today)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
