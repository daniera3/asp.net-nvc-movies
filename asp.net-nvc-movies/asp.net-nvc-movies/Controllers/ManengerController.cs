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

            ImgeDal dal = new ImgeDal();
            if (ModelState.IsValid)
            {
                dal.Image.Add(T.movie.Img);
                dal.SaveChanges();
            }
                return View(T);  
        }


        public ActionResult GetMoviesByJson()
        {
            MoviesDal dal = new MoviesDal();
            List<Movies> objmovies = dal.Movie.ToList<Movies>();
            return Json(objmovies, JsonRequestBehavior.AllowGet);
        }

        


        public ActionResult AddNewMovie()
        {
            MoviesDal dal = new MoviesDal();
            MoviesModelView T = new MoviesModelView
            {
                movies = dal.Movie.ToList<Movies>()
            };
            return View(T);

        }
    }
}