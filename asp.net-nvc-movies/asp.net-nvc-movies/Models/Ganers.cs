using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace asp.net_nvc_movies.Models
{
    public class Ganers
    {
        [Key]
        public int Idmovie { get; set; }
        [Required]
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
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Length must be between 2 and 50 characters")]
        [Required]
        public string NameMovies { get; set; }
        public string NameIMG { get; set; }
        [Key]
        public int Idmovie { get; set; }
    }
}