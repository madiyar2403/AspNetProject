using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class PriceAttribute : ValidationAttribute
    {
        public double MinPrice { get; set; }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            var price = (decimal)value;
            if (price < (decimal)MinPrice)
            {
                return false;
            }
            decimal teens = price - Math.Truncate(price);
            //price = price - teens;


            return true;
        }
    }
}