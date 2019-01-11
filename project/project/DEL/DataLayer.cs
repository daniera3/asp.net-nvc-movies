
using project.Models;
using System.Data.Entity;

namespace project.DEL
{
    public class DataLayer : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().ToTable("Movies");
        }

        public DataLayer() : base("name=MoviesDel")//Name for connection string in the web config.
        {
        }

        public DbSet<Movies> Movies { get; set; }

        public DbSet<Imge> Imges { get; set; }

        public DbSet<Star> Stars { get; set; }
        public DbSet<Ganers> Ganers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
