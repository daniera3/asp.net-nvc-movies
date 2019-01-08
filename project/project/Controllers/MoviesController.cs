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

            
            return View();

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
            if (num == null)
                num = "10";
          
            ViewBag.num = num;
            D.movies = (from x in db.Movies
                        orderby  num,x.Rating descending
                        select x ).ToList<Movies>();
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

        public ActionResult Genre()
        {

            return View();

        }
 
      
        public ActionResult MoviesPerGaner(string ganer)
        {
            
            return View();
        }
        public ActionResult search()
        {
            String VSearch = Request.Form["Text1"];
             D.movies= (from x in db.Movies
                               where x.Title.Contains(VSearch)
                               select x).ToList<Movies>();


            return View(D);
        }


    }

}