
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net_nvc_movies.DEL;
using asp.net_nvc_movies.Models;
using asp.net_nvc_movies.ModelView;

namespace asp.net_nvc_movies.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesModelView GetData()
        {
            movies_Dal dal = new movies_Dal();
            MoviesModelView T = new MoviesModelView
            {
                movies = dal.Movie.ToList<Movies>()
            };
            return T;
        }
        // GET: Movies


        public ActionResult CMovie()
        {
            
            return View();

        }

       
        public ActionResult Movie()
        {

            return View(GetData());

        }


        
        public ActionResult Top10(string num)
        {
          
            ViewBag.num = num;
            return View(GetData());
            
        }

        public ActionResult Genre()
        {

            return View(GetData());

        }
 
      
        public ActionResult MoviesPerGaner(string ganer)
        {
            
            return View(GetData());
        }
      
    }

}