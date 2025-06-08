using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Validation
{
    public class CustomHoursValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int hours = (int)value;

            if (hours % 3 != 0)
                return new ValidationResult("Hours must be a multiple of 3.");

            return ValidationResult.Success;
        }
    }

}
