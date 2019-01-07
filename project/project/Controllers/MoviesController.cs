using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using project.DEL;
using project.Models;


namespace asp.net_nvc_movies.Controllers
{
    public class MoviesController : Controller
    {
        private Movie_del db = new Movie_del();
        private MoviesModelView D = new MoviesModelView();
        // GET: Movies


        public ActionResult CMovie()
        {
            
            return View();

        }

       
        public ActionResult Movie()
        {

            D.movies = db.Movies.ToList<Movies>();
            
            return View(D);

        }


        
        public ActionResult Top10(string num)
        {
          
            ViewBag.num = num;
            return View();
            
        }

        public ActionResult Genre()
        {

            return View();

        }
 
      
        public ActionResult MoviesPerGaner(string ganer)
        {
            
            return View();
        }
      
    }

}