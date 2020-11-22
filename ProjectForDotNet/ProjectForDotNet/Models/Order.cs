using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
        public int TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}