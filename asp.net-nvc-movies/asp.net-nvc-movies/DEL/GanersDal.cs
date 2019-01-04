﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using asp.net_nvc_movies.Models;


namespace asp.net_nvc_movies.DEL
{
    public class GanersDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().ToTable("genre");
        }
        public DbSet<Movies> Genre { get; set; }
    }
}