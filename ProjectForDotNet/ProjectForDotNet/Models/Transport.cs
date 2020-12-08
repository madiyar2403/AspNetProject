using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectForDotNet.Models
{
    public class Transport
    {
        public int? TransportId { get; set; }
        [Required(ErrorMessage = "Please enter transport's name")]
        [Display(Name = "Transport Name")]
        [StringLength(50)]
        [Remote("VerifyName", "Transports", HttpMethod = "POST", AdditionalFields = "TransportId", ErrorMessage = "Name of this transport already exists in database.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter transport's weight")]
        [Display(Name = "Weight")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Please enter transport's capacity")]
        [Range(0, 2000, ErrorMessage = "Please enter correct range between 0 and 5000")]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Please enter transport's maximum speed")]
        [Display(Name = "Max speed")]
        [Range(0, 2000, ErrorMessage = "Please enter correct range between 0 and 2000")]
        public int MaxSpeed { get; set; }
        [Required(ErrorMessage = "Please enter transport's producer")]
        [Display(Name = "Producer ")]
        public string Producer { get; set; }
        [Required(ErrorMessage = "Please enter transport's description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter transport's price")]
        [Display(Name = "Price")]
        [Range(100, 10000000000000, ErrorMessage = "Please enter correct range between 100 and 10000000000000")]
        [Price(MinPrice = 100.00)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter transport's image url")]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}