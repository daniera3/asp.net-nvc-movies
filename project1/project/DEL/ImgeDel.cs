using project.Models;
using System.Data.Entity;

namespace project.DEL
{
    public class ImgeDel : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Imge>().ToTable("Imges");
        }

        public ImgeDel() : base("name=ImgeDel")
        {
        }

        public DbSet<Imge> Imags { get; set; }
    }
}