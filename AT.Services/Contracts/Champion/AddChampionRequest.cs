using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AT.Services.Contracts.Champion
{
    public class AddChampionRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ChampionId { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public string[] Traits { get; set; }
    }
}
