using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace project.Models
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
        
        public Imge() {
        }
        public Imge(int id, string url, string titl, string alt)
        {
            Idmovie = id;
            img = url;
            title = titl;
            this.alt = alt;
        }
    }
}