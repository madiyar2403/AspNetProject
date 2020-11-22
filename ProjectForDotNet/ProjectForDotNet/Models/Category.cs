using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class Category //Air: Helicopter, Plane. Land: Car, Truck, etc.
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}