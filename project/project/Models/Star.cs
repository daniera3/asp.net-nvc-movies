using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Star
    {
        [Key, Column(Order = 1)]
        public int Idmovie { get; set; }
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(50, MinimumLength =2, ErrorMessage ="Length must be between 2 and 50 characters")]
        public string Namestar { get; set; }
        public Star(string url, int id)
        {
            Idmovie = id;
            Namestar = url;
        }

        public Star()
        {
        }
    }
}