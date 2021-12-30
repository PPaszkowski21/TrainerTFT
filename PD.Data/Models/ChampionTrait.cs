using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AT.Data.Models
{
    [Table("ChampionTraits")]
    public class ChampionTrait
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ChampionId { get; set; }
        public string TraitKey { get; set; }
    }
}
