using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AT.Services.Contracts.Traits
{
    public class AddTraitSetRequest
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Style { get; set; }
        [Required]
        public int Min { get; set; }
        [Required]
        public int Max { get; set; }
    }
}
