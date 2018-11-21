using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly_New.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0) return ValidationResult.Success;

            if (customer.Birthday == null) return new ValidationResult("Birthdate is required!");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be older than 18 year");
        }
    }
}