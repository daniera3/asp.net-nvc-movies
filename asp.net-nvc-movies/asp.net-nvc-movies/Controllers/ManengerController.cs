using asp.net_nvc_movies.DEL;
using asp.net_nvc_movies.Models;
using asp.net_nvc_movies.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_nvc_movies.Controllers
{
    public class ManengerController : Controller
    {
        // GET: ADMIN
        [HttpPost]
        public ActionResult Submit1(MoviesModelView T)
        {

            movies_Dal dal = new movies_Dal();
            if (ModelState.IsValid)
            {
                T.movie.addG(T.genres);
                T.movie.addS(T.stars);
                T.movie.addD(T.directors);
                dal.Movie.Add(T.movie);
                dal.SaveChanges();
            }
                return View(T);  
        }


        public ActionResult GetMoviesByJson()
        {
            movies_Dal dal = new movies_Dal();
            List<Movies> objmovies = dal.Movie.ToList<Movies>();
            return Json(objmovies, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddStar(MoviesModelView T) {
            if(T.stars.Namestar!=null)
            T.movie.addS(T.stars);
            
            return View(T);
        }


        public ActionResult AddGaner(MoviesModelView T) {
            T.movie.addG(T.genres);
            return View(T);
        }


        public ActionResult AddDir(MoviesModelView T) {
            T.movie.addD(T.directors);
            return View(T);

        }

        public ActionResult AddNewMovie()
        {
            movies_Dal dal = new movies_Dal();
            MoviesModelView T = new MoviesModelView
            {
                movies = dal.Movie.ToList<Movies>()
            };
            return View(T);

        }
    }
}