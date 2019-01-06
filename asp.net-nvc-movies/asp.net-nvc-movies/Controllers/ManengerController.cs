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

        Bb_Dal dal = new Bb_Dal();
        MoviesModelView T = new MoviesModelView();

    // GET: ADMIN
            [HttpPost]
        public ActionResult Submit1(MoviesModelView T)
        {

           
            if (ModelState.IsValid)
            {

                dal.Movie.Add(T.movie);
                dal.SaveChanges();
            }
            return View("AddNewMovie", T);
        }

        
        public ActionResult GetMoviesByJson()
        {
           
            List<Movies> objmovies = dal.Movie.ToList<Movies>();
            return Json(objmovies, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddStar(String idmovie) {
          
            return View(T);
        }

        [HttpPost]
        public ActionResult AddGaner(String idmovie) {
           // T.movie.addG(G.genres);
            return View(T);
        }

        [HttpPost]
        public ActionResult AddDir(String idmovie) {
           // T.movie.addD(G.directors);
            return View(T);

        }

        public ActionResult AddNewMovie(MoviesModelView G)
        {
            T = G;
            T.movies = dal.Movie.ToList<Movies>();
            return View(T);

        }
    }
}