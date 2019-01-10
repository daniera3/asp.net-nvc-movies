using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.ModelView
{
    public class GanersViewModel
    {
        

        public GanersViewModel(string s, List<Movies> movies)
        {
            this.NameGaner = s;
            this.movies = movies;
        }

        public String NameGaner { get; set; }
        public List<Movies> movies { get; set; }

    }
    public class ListGanersViewModel
    {
        public List<GanersViewModel> GanersList { get; set; }
        public ListGanersViewModel() { this.GanersList = new List<GanersViewModel>(); }
    }
}