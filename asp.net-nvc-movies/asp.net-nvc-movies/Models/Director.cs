using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_nvc_movies.Models
{

    public class Director
    {
        [Key, Column(Order = 2)]
        public int idmovie { get; set; }
        [Required]
        [Key, Column(Order = 1)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Length must be between 2 and 50 characters")]
        public string NameDirector { get; set; }

        public Director(string url, int id)
        {
            idmovie = id;
            NameDirector = url;
        }

        public Director()
        {
        }
    }
}