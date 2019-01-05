using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_nvc_movies.Models
{
    public class Ganers
    {
        [Key, Column(Order = 2)]
        public int Idmovie { get; set; }
        [Required]
        [Key, Column(Order = 1)]
        public string NameGaner { get; set; }
        public List<NameMoviesAndIMG> NMAndIMG { get; set; }
        public Ganers() { }
        public Ganers(string url, int id)
        {
            NMAndIMG = new List<NameMoviesAndIMG>();
            Idmovie = id;
            NameGaner = url;
        }
    }
    public class NameMoviesAndIMG
    {
        public NameMoviesAndIMG(int a, string b, string c) { Idmovie = a; NameMovies = b; NameIMG = c; }
        public string NameMovies { get; set; }
        public string NameIMG { get; set; }
        [Key]
        public int Idmovie { get; set; }
    }
}