using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using asp.net_nvc_movies.Models;


namespace asp.net_nvc_movies.DEL
{
    public class ImgeDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().ToTable("movieimg");
        }
        public DbSet<Movies> Image { get; set; }
    }
}