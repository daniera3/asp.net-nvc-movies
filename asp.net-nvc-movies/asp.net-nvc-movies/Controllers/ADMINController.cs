using asp.net_nvc_movies.DEL;
using asp.net_nvc_movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_nvc_movies.Controllers
{
    public class ADMINController : Controller
    {
        // GET: ADMIN
        public ActionResult AddStars()
        {
            return View();
        }

        public ActionResult AddNewMovie(Movies movie)
        {
            if (ModelState.IsValid)
            {
                MoviesDal dal = new MoviesDal();
                dal.Movie.Add(movie);
                dal.SaveChanges();
                return View(movie);
            }
            else
                return View(movie);

        }
    }
}