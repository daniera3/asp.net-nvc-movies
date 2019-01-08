using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using project.DEL;
using project.Models;


namespace project.Controllers
{
    public class MoviesController : Controller
    {
        private Movie_del db = new Movie_del();
        private MoviesModelView D = new MoviesModelView();
        // GET: Movies



        public ActionResult CMovie(int id)
        {

            D.movie = (from x in db.Movies
                       where x.Idmovie.Equals(id)
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

            D.movies = db.Movies.ToList<Movies>();
            foreach(Movies movie in D.movies)
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


        
        public ActionResult Top10(string num)
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

        public ActionResult Genre()
        {

           
            D.movie.Ganer = (from x in db.Ganers
                             select x).ToList<Ganers>();
            foreach (Ganers G in D.movie.Ganer)
            {
                D.movies = (from x in db.Movies
                            where x.Idmovie.Equals(G.Idmovie)
                            select x).Take(3).ToList<Movies>();
            }
            foreach (Movies movie in D.movies)
            {
                movie.Img = (from x in db.Imges
                             where x.Idimg.Equals(movie.Idimg)
                             select x).ToList<Imge>()[0];
            }
            return View(D);

        }


        public ActionResult MoviesPerGaner(string ganer)
        {

            
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
        public ActionResult search()
        {

                String VSearch = Request.Form["name movie"];

                D.movies= (from x in db.Movies
                               where x.Title.Contains(VSearch)
                               select x).ToList<Movies>();


            return View(D);
        }


    }

}