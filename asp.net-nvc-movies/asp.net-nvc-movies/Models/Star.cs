using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp.net_nvc_movies.Models
{
    public class Star
    {
        [Key]
        public int Idmovie { get; set; }
        public string Namestar { get; set; }
        public Star(string url, int id)
        {
            Idmovie = id;
            Namestar = url;
        }
    }
}