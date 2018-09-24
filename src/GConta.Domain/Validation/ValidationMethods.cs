using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GConta.Domain.Validation
{
    public class ValidationMethods
    {
        public static ValidationResult ValidateGreaterToZero(decimal value, ValidationContext context)
        {
            bool isValid = true;

            if (value <= decimal.Zero)
            {
                isValid = false;
            }

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(
                    string.Format("The field {0} must be greater than to 0.", context.MemberName),
                    new List<string> { context.MemberName });
            }
        }
    }
}
