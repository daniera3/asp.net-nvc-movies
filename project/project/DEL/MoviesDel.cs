
using project.Models;
using System.Data.Entity;

namespace project.DEL
{
    public class Movies_Del : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().ToTable("Movies");
        }

        public Movies_Del() : base("name=MoviesDel")
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
