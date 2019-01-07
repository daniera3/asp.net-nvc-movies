

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

        private Movie_del dal = new Movie_del();
        private MoviesModelView D=new MoviesModelView() ;
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
        [HttpPost]
        public ActionResult SubmitS(MoviesModelView T)
        {
            try
            {
                var id = T.movie.Title.Split(' ').GetValue(0);
                dal.Stars.Add(new Star(T.stars.Namestar, Int32.Parse(id.ToString())));
                dal.SaveChanges();
            }
            
            catch (Exception)
            {
                return View(T);
            }
            
            return View(T);
        }
        [HttpPost]
        public ActionResult SubmitD(MoviesModelView T)
        {


            try
            {
                var id = T.movie.Title.Split(' ').GetValue(0);
                dal.Directors.Add(new Director(T.directors.NameDirector, Int32.Parse(id.ToString())));
                dal.SaveChanges();
            }

            catch (Exception )
            {
              
                return View(T);
            }

            return View(T);
        }
        [HttpPost]
        public ActionResult SubmitG(MoviesModelView T)
        {


            try
            {
                var id = T.movie.Title.Split(' ').GetValue(0);
                dal.Ganers.Add(new Ganers(T.genres.NameGaner, Int32.Parse(id.ToString())));
                dal.SaveChanges();
            }

            catch (Exception )
            {
              
                return View(T);
            }

            return View(T);
        }

        public ActionResult GetMoviesByJson()
        {
           
            List<Movies> objmovies = dal.Movies.ToList<Movies>();
            return Json(objmovies, JsonRequestBehavior.AllowGet);
        }

        
       
        public ActionResult AddStar() {
            D.movies = dal.Movies.ToList<Movies>();
            return View(D);
        }

        
        
        public ActionResult AddGaner() {
            D.movies = dal.Movies.ToList<Movies>();
            return View(D);
        }

        
        
        public ActionResult AddDir() {
            D.movies = dal.Movies.ToList<Movies>();
            return View(D);

        }

        public ActionResult AddNewMovie()
        {
            
            D.movies = dal.Movies.ToList<Movies>();
            return View(D);

        }
    }
}