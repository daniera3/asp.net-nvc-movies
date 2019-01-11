using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using project.DEL;
using project.Models;

namespace project.Controllers
{
    [Authorize]//Only authorized personnel may access this. Else, sends to home index view.
    public class ManengerController : Controller
    {
      
    private DataLayer dal = new DataLayer();
        private MoviesModelView D=new MoviesModelView() ;

     
        public ActionResult Submit1()
            {
            Movies movie = new Movies();//Creates new movie and fills it from the sent form.
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
            Thread.Sleep(4000);//Sleep in order to show async.
            List<Movies> objmovies = dal.Movies.ToList<Movies>();//Retrieves all the movie data from the db. 
            return Json(objmovies, JsonRequestBehavior.AllowGet);//Creates Json from the data collected above.
        }
        [HttpPost]
        public ActionResult SubmitS(MoviesModelView T)//Stars submitting.
        {
            try
            {
                var id = T.movie.Title.Split(' ').GetValue(0);//Retrieves the id from the user's choice.
                dal.Stars.Add(new Star(T.stars.Namestar, Int32.Parse(id.ToString())));//Saves in the memory and creates a new star.
                dal.SaveChanges();
            }
            
            catch (Exception)
            {
                return View();
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult SubmitD(MoviesModelView T)//Submits directors.
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
        public ActionResult SubmitG(MoviesModelView T)//Submits genres.
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
            Thread.Sleep(4000);//Sleep in order to show async.
            List<Movies> objmovies = dal.Movies.ToList<Movies>();//Retrieves all the movie data from the db. 
            return Json(objmovies, JsonRequestBehavior.AllowGet);//Creates Json from the data collected above.
        }

        
       
        public ActionResult AddStar() {//Collects all the info about the movie from the DB and sends it to the corresponding view.
            D.movies = dal.Movies.ToList<Movies>();
            return View(D);
        }

        
        
        public ActionResult AddGaner() {//Collects all the info about the movie from the DB and sends it to the corresponding view.
            D.movies = dal.Movies.ToList<Movies>();
            return View(D);
        }

        
        
        public ActionResult AddDir() {//Collects all the info about the movie from the DB and sends it to the corresponding view.
            D.movies = dal.Movies.ToList<Movies>();
            return View(D);

        }

        public ActionResult AddNewMovie()//Collects all the info about the movie from the DB and sends it to the corresponding view.
        {
            
            D.movies = dal.Movies.ToList<Movies>();
            return View(D);

        }
    }
}