using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace asp.net_nvc_movies.Models
{

    public class Director
    {
        [Key]
        public int idmovie { get; set; }
        public string NameDirector { get; set; }

        public Director(string url, int id)
        {
            idmovie = id;
            NameDirector = url;
        }
    }
}