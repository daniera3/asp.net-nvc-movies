using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using asp.net_nvc_movies.Models;


namespace asp.net_nvc_movies.DEL
{
    public class StarDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().ToTable("star");
        }
        public DbSet<Movies> Stars { get; set; }
    }
}