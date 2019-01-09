using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.ModelView
{
    public class GanersViewModel
    {
        private string s;

        public GanersViewModel(string s, List<Movies> movies)
        {
            this.s = s;
            this.movies = movies;
        }

        public String NameGaner { get; set; }
        public List<Movies> movies { get; set; }

    }
}