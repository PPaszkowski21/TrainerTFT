using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AT.Services.Contracts.Champion
{
    public class ChampionOnTheBoardRequest
    {
        [Required]
        public string ChampionId { get; set; }

        [Required]
        public int CopiesBought { get; set; }
    }
}
