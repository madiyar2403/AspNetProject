using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDotNet.Models
{
    public class Type //Air, Land, etc.
    {
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}