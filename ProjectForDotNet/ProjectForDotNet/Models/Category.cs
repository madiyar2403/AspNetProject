using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class Category : IValidatableObject //Air: Helicopter, Plane. Land: Car, Truck, etc.
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Name))
                errors.Add(new ValidationResult("Any name is selected"));

            if (string.IsNullOrWhiteSpace(this.Description))
                errors.Add(new ValidationResult("Any description is selected"));

            return errors;
        }
    }
}