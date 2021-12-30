using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AT.Services.Contracts.Traits
{
    public class GetTrait
    {
        [Required]
        public List<string> ChampionIds { get; set; }
    }
}
