using asp.net_nvc_movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net_nvc_movies.ModelView
{
    public class MoviesModelView
    {
        public MoviesModelView()
        {
            movie = new Movies();
            movies = new List<Movies>();
            stars = new Star();
            directors = new Director();
            genres = new Ganers();
        }
        public Movies movie { get; set; }

        public List<Movies> movies { get; set; }

        public Star stars { get; set; }
        public Director directors { get; set; }
        public Ganers genres { get; set; }
    }
}