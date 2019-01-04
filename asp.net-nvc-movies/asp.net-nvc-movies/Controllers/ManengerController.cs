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
        public ActionResult AddStars()
        {
            return View();
        }

        public ActionResult AddNewMovie(MoviesModelView m)
        {
            
            if (ModelState.IsValid)
            {
                MoviesDal dal = new MoviesDal();
                dal.Movie.Add(m.movie);
                dal.SaveChanges();
                return View(m);
            }
            else
                return View(m);

        }
    }
}