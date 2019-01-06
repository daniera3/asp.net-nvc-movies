
using project.Models;
using System.Data.Entity;

namespace project.DEL
{
    public class MoviesDel : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().ToTable("Movies");
        }

        public MoviesDel() : base("name=MoviesDel")
        {
        }

        public DbSet<Movies> Movies { get; set; }
    }
}
