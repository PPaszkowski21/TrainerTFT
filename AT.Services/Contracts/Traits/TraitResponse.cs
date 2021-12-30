using AT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Services.Contracts.Traits
{
    public class TraitResponse
    {
        public string Name { get; set; }
        public string Style { get; set; }
        public int Active { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        
    }
}
