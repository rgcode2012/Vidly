using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Bithdate == null)
                return new ValidationResult("Birthdate is Required.");

            var age = DateTime.Now.Year - customer.Bithdate.Value.Year;

            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer Should be at least 18 years old for the current membership Type");

        }
    }
}