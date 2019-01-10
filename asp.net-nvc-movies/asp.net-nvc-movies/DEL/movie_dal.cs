using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using asp.net_nvc_movies.Models;


namespace asp.net_nvc_movies.DEL
{
    public class Bb_Dal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().ToTable("Movie");
        }
 
        public DbSet<Ganers> ganer { get; set; }
        public DbSet<Star> star { get; set; }
        public DbSet<Director> director { get; set; }
        public DbSet<Movies> Movie { get; set; }
    }
}