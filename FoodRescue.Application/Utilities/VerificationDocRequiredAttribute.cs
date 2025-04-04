using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Application.Utilities
{
    public class VerificationDocRequiredAttribute : ValidationAttribute
    {
      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            var instance = validationContext.ObjectInstance;

         
            var IsCharity = bool.Parse(instance.GetType().GetProperty("IsCharity")?.GetValue(instance)?.ToString()!);
            
            if (IsCharity  && value == null)
            {
                return new ValidationResult($"Verification document is required for charities.");
            }

            
            return ValidationResult.Success;
        }
    }
}