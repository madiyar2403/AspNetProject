using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class Type : IValidatableObject //Air, Land, etc.
    {
        public int TypeId { get; set; }
        [Display(Name = "Type's name")]
        public string Name { get; set; }
        public string Description { get; set; }
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