using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Ganers
    {
        [Key, Column(Order = 1)]
        public int Idmovie { get; set; }
        [Required]
        [Key, Column(Order = 2)]
        public string NameGaner { get; set; }
       
        public Ganers() { }
        public Ganers(string url, int id)
        {
            Idmovie = id;
            NameGaner = url;
        }
    }
}