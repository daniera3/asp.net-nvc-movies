
using project.Models;
using System.Data.Entity;

namespace project.DEL
{
    public class DirectorDel : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Director>().ToTable("Directors");
        }

        public DirectorDel() : base("name=DirectorDel")
        {
        }

        public DbSet<Director> Imags { get; set; }
    }
}