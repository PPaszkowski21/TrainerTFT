using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Data.Models
{
    public class TrainerTftDbContext : DbContext
    {

        public TrainerTftDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ChampionCard> ChampionCards { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<TraitSets> Sets { get; set; }
        public DbSet<ChampionTrait> ChampionTraits { get; set; }
    }
}
