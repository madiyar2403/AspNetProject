using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class Transport
    {
        public int TransportId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Capacity { get; set; }
        public int MaxSpeed { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}