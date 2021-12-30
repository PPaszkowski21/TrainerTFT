using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AT.Services.Contracts.Champion
{
    public class GetDeckRequest
    {
        [Required]
        public List<ChampionOnTheBoardRequest> ChampionsOnTheBoard { get; set; }
        [Required]
        public double[] Percentage { get; set; }
    }
}
