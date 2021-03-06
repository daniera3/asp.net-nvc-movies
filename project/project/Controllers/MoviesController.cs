﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using project.DEL;
using project.Models;
using project.ModelView;

namespace project.Controllers
{
    public class MoviesController : Controller
    {
        private DataLayer db = new DataLayer();
        private MoviesModelView D = new MoviesModelView();
        // GET: Movies



        public ActionResult CMovie(String id)//Gets the id from the movie, the info about the movie which the id belongs to and sends to the view.
        {

            D.movie = (from x in db.Movies
                       where x.Idmovie.ToString().Equals(id)
                       select x).ToList<Movies>()[0];
            D.movie.Img = (from x in db.Imges
                           where x.Idimg.Equals(D.movie.Idimg)
                           select x).ToList<Imge>()[0];
            D.movie.Str = (from x in db.Stars
                           where x.Idmovie.Equals(D.movie.Idmovie)
                           select x).ToList<Star>();
            D.movie.Ganer = (from x in db.Ganers
                             where x.Idmovie.Equals(D.movie.Idmovie)
                             select x).ToList<Ganers>();
            D.movie.Dir = (from x in db.Directors
                           where x.idmovie.Equals(D.movie.Idmovie)
                           select x).ToList<Director>();


            return View(D.movie);

        }

        public ActionResult Movie()
        {

            D.movies = db.Movies.ToList<Movies>();//Collects all the info about the movies from the DB and sends it to the corresponding view.
            foreach (Movies movie in D.movies)
            {
                movie.Img =(from x in db.Imges
                             where x.Idimg.Equals(movie.Idimg)
                             select x).ToList<Imge>()[0];
                movie.Str= (from x in db.Stars
                            where x.Idmovie.Equals(movie.Idmovie)
                            select x).ToList<Star>();
                movie.Ganer = (from x in db.Ganers
                             where x.Idmovie.Equals(movie.Idmovie)
                             select x).ToList<Ganers>();
                movie.Dir = (from x in db.Directors
                             where x.idmovie.Equals(movie.Idmovie)
                             select x).ToList<Director>();
            }
            return View(D);

        }


        
        public ActionResult Top10(string num)//Collects all the info about the movie from the DB sorted by rating and number given and sends it to the corresponding view.
        {
          
            ViewBag.num = num;

            D.movies = (from x in db.Movies
                        orderby x.Rating descending
                        select x).Take(Int32.Parse(num)).ToList<Movies>();
            foreach (Movies movie in D.movies)
            {
                movie.Img =(from x in db.Imges
                             where x.Idimg.Equals(movie.Idimg)
                             select x).ToList<Imge>()[0];
                movie.Str= (from x in db.Stars
                            where x.Idmovie.Equals(movie.Idmovie)
                            select x).ToList<Star>();
                movie.Ganer = (from x in db.Ganers
                             where x.Idmovie.Equals(movie.Idmovie)
                             select x).ToList<Ganers>();
                movie.Dir = (from x in db.Directors
                             where x.idmovie.Equals(movie.Idmovie)
                             select x).ToList<Director>();
            }
            return View(D);
        
            
        }

        public ActionResult Gener()//Collects all the info about the movie from the DB sorted by genres, 3 shown at a time and sends it to the corresponding view.
        {
            
            List<GanersViewModel> Ganer = new List<GanersViewModel>();

             List<string> tamp = (from x in db.Ganers
                              select x.NameGaner).Distinct().ToList<string>();
            foreach (String s in tamp)
            {

                List<Ganers> ganerlist = (from x in db.Ganers
                                 where x.NameGaner.Equals(s)
                                 select x).Take<Ganers>(3).ToList<Ganers>();
                List<Movies> m = new List<Movies>();
                foreach (Ganers G in ganerlist)
                {
                    m.Add((from x in db.Movies
                                where x.Idmovie.Equals(G.Idmovie)
                                select x).ToList<Movies>()[0]);
                }
                foreach (Movies movie in m)
                {
                    movie.Img = (from x in db.Imges
                                 where x.Idimg.Equals(movie.Idimg)
                                 select x).ToList<Imge>()[0];
                }
                Ganer.Add(new GanersViewModel(s, m));
            }
            return View(new ListGanersViewModel() { GanersList = Ganer });

        }


        public ActionResult MoviesPerGaner(string ganer)//Collects the movie info only corresponding to a chosen genre.
        {
            ViewBag.ganer= ganer;
            List<Ganers> Ganer = new List<Ganers>();
            Ganer = (from x in db.Ganers
                     where x.NameGaner.Equals(ganer)
                     select x).ToList<Ganers>();
            foreach (Ganers G in Ganer)
            {
                D.movies = (from x in db.Movies
                            where x.Idmovie.Equals(G.Idmovie)
                            select x).ToList<Movies>();
            }
            foreach (Movies movie in D.movies)
            {
                movie.Img = (from x in db.Imges
                             where x.Idimg.Equals(movie.Idimg)
                             select x).ToList<Imge>()[0];
                movie.Str = (from x in db.Stars
                             where x.Idmovie.Equals(movie.Idmovie)
                             select x).ToList<Star>();
                movie.Ganer = (from x in db.Ganers
                               where x.Idmovie.Equals(movie.Idmovie)
                               select x).ToList<Ganers>();
                movie.Dir = (from x in db.Directors
                             where x.idmovie.Equals(movie.Idmovie)
                             select x).ToList<Director>();
            }
            return View(D);
        }
        public ActionResult search()//Retrieves the movie info according to a movie title chosen out of the given options.
        {

                String VSearch = Request.Form["name movie"];

                D.movies= (from x in db.Movies
                               where x.Title.Contains(VSearch)
                               select x).ToList<Movies>();

            return View(D);
        }


    }

}