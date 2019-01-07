

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using project.DEL;
using project.Models;

namespace project.Controllers
{
    public class ManengerController : Controller
    {

        private Movies_Del dal = new Movies_Del();

        [HttpPost]
        public ActionResult Submit1(MoviesModelView T)
        {

           
            if (ModelState.IsValid)
            {

                dal.Movies.Add(T.movie);
                dal.SaveChanges();
            }
            return View("AddNewMovie", T);
        }

        
        public ActionResult GetMoviesByJson()
        {
           
            List<Movies> objmovies = dal.Movies.ToList<Movies>();
            return Json(objmovies, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult AddStar() {
          
            return View();
        }

        
        public ActionResult AddGaner() {
            return View();
        }

        
        public ActionResult AddDir() {

            return View();

        }

        public ActionResult AddNewMovie()
        {
            MoviesModelView T=new MoviesModelView() ;
            T.movies = dal.Movies.ToList<Movies>();
            return View(T);

        }
    }
}