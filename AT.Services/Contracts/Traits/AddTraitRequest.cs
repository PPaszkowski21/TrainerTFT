using AT.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AT.Services.Contracts.Traits
{
    public class AddTraitRequest
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public AddTraitSetRequest[] Sets { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
