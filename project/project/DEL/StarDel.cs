using project.Models;
using System.Data.Entity;

namespace project.DEL
{
    public class StarDel : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Star>().ToTable("Stars");
        }

        public StarDel() : base("name=StarDel")
        {
        }

        public DbSet<Star> Stars { get; set; }
    }
}