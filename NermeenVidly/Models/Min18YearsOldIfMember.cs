using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NermeenVidly.Models
{
    public class Min18YearsOldIfMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate is null)
                return new ValidationResult("BirthDate is required");

            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;
            return (age >=18)? ValidationResult.Success:
                new ValidationResult("Member age should be greater than 18 years old");
    
        }
    }
}