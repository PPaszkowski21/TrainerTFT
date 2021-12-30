using AT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Services.Contracts.Champion
{
    public class ShopOfferChampionResponse
    {
        public ChampionCard Champion { get; set; }
        public List<Trait> Traits { get; set; }
    }
}
