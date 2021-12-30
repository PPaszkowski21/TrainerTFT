using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AT.Data.Models
{
    [Table("ChampionCard")]
    public class ChampionCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ChampionId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public byte[] ShopCard { get; set; }
        public byte[] Avatar { get; set; }

        
    }
}
