using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using project.DEL;
using project.Models;

namespace project.Controllers
{
    [Authorize]
    public class ManengerController : Controller
    {

        private DataLayer dal = new DataLayer();
        private MoviesModelView D=new MoviesModelView() ;

     
        public ActionResult Submit1()
            {
            Movies movie = new Movies();
            movie.Img.img = Request.Form["movie.Img.img"].ToString();
            movie.Img.title = Request.Form["movie.Img.title"].ToString();
            movie.Img.alt = Request.Form["movie.Img.alt"].ToString();
            movie.Title = Request.Form["movie.Title"].ToString();
            movie.Rating = Int32.Parse(Request.Form["movie.Rating"].ToString());
            movie.Outline = Request.Form["movie.Outline"].ToString();
            movie.Certificate = Request.Form["movie.Certificate"].ToString();
            movie.Time = Request.Form["movie.Time"].ToString();

            if (ModelState.IsValid)
            {

                dal.Movies.Add(movie);
                dal.SaveChanges();
            }
            List<Movies> objmovies = dal.Movies.ToList<Movies>();
            return Json(objmovies, JsonRequestBehavior.AllowGet);
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
                return View();
            }
            
            return View();
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
              
                return View();
            }

            return View();
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
              
                return View();
            }

            return View();
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