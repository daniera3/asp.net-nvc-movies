using project.Models;
using System.Data.Entity;

namespace project.DEL
{
    public class GanerDel : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ganers>().ToTable("Ganers");
        }

        public GanerDel() : base("name=GanerDel")
        {
        }

        public DbSet<Ganers> Ganers { get; set; }
    }
}