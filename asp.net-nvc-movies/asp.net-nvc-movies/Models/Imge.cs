using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace asp.net_nvc_movies.Models
{
    public class Imge
    {
        [Key]
        public int Idmovie { get; set; }
        [Required]
        public string img { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string alt { get; set; }
        
        public string width { get; set; }
        
        public string height { get; set; }

        public Imge() {
        }
        public Imge(int id, string url, string titl, string alt, string width, string height)
        {
            Idmovie = id;
            img = url;
            title = titl;
            this.alt = alt;
            this.width = width;
            this.height = height;
        }
    }
}