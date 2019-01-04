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
        public ActionResult Submit()
        {

            return View();
        }

        public ActionResult AddNewMovie(MoviesModelView t)
        {
            MoviesDal dal = new MoviesDal();
            MoviesModelView m = new MoviesModelView();
            m.movies = dal.Movie.ToList<Movies>();
            if (ModelState.IsValid)
            {
                dal.Movie.Add(m.movie);
                dal.SaveChanges();
                m.movie = new Movies();
            }

                return View(t);

        }
    }
}