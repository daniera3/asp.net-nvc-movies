
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using IronPython;
using Microsoft.Scripting.Hosting;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {

        string BaseDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        string BDirectory = Path.GetDirectoryName((Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));

        // GET: Movies
        /* private void getMoviesAndGaners()
         {
             List<Movies> Movie=new List<Movies>();
             List<Ganers> Ganer= new List<Ganers>();
             string path;
             string DataBacePath = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=" + BaseDirectory + @"\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True";
             path = BaseDirectory + @"\App_Data\allMovies.json"; 
             try
             {
                 try
                 {
                     using (StreamReader r = new StreamReader(path))
                     {
                         string json = r.ReadToEnd();
                         Movie = JsonConvert.DeserializeObject<List<Movies>>(json);

                         TempData["MovieList"] = Movie;
                     }
                 }

                 catch (Exception)
                 {
                     Process process = new Process();
                     process.StartInfo.FileName = BDirectory + @"\wecandothis\candoit\bin\Debug\candoit.exe";
                     process.StartInfo.Arguments = DataBacePath + " " + path;
                     process.StartInfo.UseShellExecute = false;
                     process.StartInfo.RedirectStandardOutput = true;
                     process.StartInfo.RedirectStandardError = true;
                     process.Start();
                     //Read the output (or the error)
                     string output = process.StandardOutput.ReadToEnd();
                     Console.WriteLine(output);
                     string err = process.StandardError.ReadToEnd();
                     Console.WriteLine(err);
                     process.WaitForExit();




                     using (StreamReader r = new StreamReader(path))
                     {
                         string json = r.ReadToEnd();
                         Movie = JsonConvert.DeserializeObject<List<Movies>>(json);

                         TempData["MovieList"] = Movie;
                     }
                 }
                 path = BaseDirectory + @"\App_Data\allGaners.json";
                 try
                 {
                     using (StreamReader r = new StreamReader(path))
                     {
                         string json = r.ReadToEnd();
                         Ganer = JsonConvert.DeserializeObject<List<Ganers>>(json);

                         TempData["GanersList"] = Ganer;
                     }
                 }
                 catch (Exception)
                 {
                     Process process = new Process();
                     process.StartInfo.FileName = BDirectory + @"\ShowGaners\ShowGaners\bin\Debug\ShowGaners.exe";
                     process.StartInfo.Arguments = DataBacePath + " " + path;
                     process.StartInfo.UseShellExecute = false;
                     process.StartInfo.RedirectStandardOutput = true;
                     process.StartInfo.RedirectStandardError = true;
                     process.Start();
                     //Read the output (or the error)
                     string output = process.StandardOutput.ReadToEnd();
                     Console.WriteLine(output);
                     string err = process.StandardError.ReadToEnd();
                     Console.WriteLine(err);
                     process.WaitForExit();

                     using (StreamReader r = new StreamReader(path))
                     {
                         string json = r.ReadToEnd();
                         Ganer = JsonConvert.DeserializeObject<List<Ganers>>(json);
                         TempData["GanersList"] = Ganer;
                     }
                 }
             }
             catch (Exception) { }
         }*/

        public ActionResult CMovie(string id)
        {/*
            Movies Cmovie = new Movies();
            try
            {

              getMoviesAndGaners();
              List<Movies> Movie = ((IEnumerable<Movies>)TempData["MovieList"]).Cast<Movies>().ToList();

                foreach (Movies mov in Movie)
                    {
                        if (mov.Idmovie.ToString() == id)
                            Cmovie = mov;
                    }
                
            }

            catch (Exception) { return View(Cmovie); }
            return View(Cmovie);

        }

       
        public ActionResult Movie(string proj)
        {
             //ViewBag.a = "https://m.media-amazon.com/images/G/01/imdb/images/certificates/us/r-2493392566._CB484113634_.png";
             //ViewBag.b = "https://m.media-amazon.com/images/M/MV5BMjA1MTIwODY4Nl5BMl5BanBnXkFtZTgwNzkxNDc2NjM@._V1_UX140_CR0,0,140,209_AL_.jpg";
             //ViewBag.d = "https://m.media-amazon.com/images/M/MV5BMjMyNzExNzQ5OV5BMl5BanBnXkFtZTgwNjM2MjIxNjM@._V1_UX140_CR0,0,140,209_AL_.jpg";
             //ViewBag.c = "https://m.media-amazon.com/images/M/MV5BOGQzZDM0NGUtZGE1NS00ZjQwLTk0N2EtMWI0NTgxYTkwYWQ4XkEyXkFqcGdeQXVyNDMzMzI5MjM@._V1_UX140_CR0,0,140,209_AL_.jpg";
             //ViewBag.e = "https://ia.media-imdb.com/images/M/MV5BMzcwMDU4NDAyMl5BMl5BanBnXkFtZTcwODAyODQ5Ng@@._V1._SY340_CR2,3,410,315_.jpg";
             //ViewBag.r = "https://ia.media-imdb.com/images/M/MV5BMTMzMTk0MzIwOV5BMl5BanBnXkFtZTcwMjY0NzYxNw@@._V1._SX250_CR0,0,250,315_.jpg";
             //ViewBag.t = "https://m.media-amazon.com/images/M/MV5BMjMzMzQ0NzI5Nl5BMl5BanBnXkFtZTgwNjc2NTY0NjM@._V1_UY209_CR0,0,140,209_AL_.jpg";
             //ViewBag.y = "https://m.media-amazon.com/images/M/MV5BNjk1Njk3YjctMmMyYS00Y2I4LThhMzktN2U0MTMyZTFlYWQ5XkEyXkFqcGdeQXVyODM2ODEzMDA@._V1_UY209_CR34,0,140,209_AL_.jpg";
             //ViewBag.s = "https://m.media-amazon.com/images/M/MV5BMTc1OTc5NzA4OF5BMl5BanBnXkFtZTgwOTAzMzE2NjM@._V1_UY209_CR0,0,140,209_AL_.jpg";
             //ViewBag.h = "https://m.media-amazon.com/images/M/MV5BNzY1MDA2OTQ0N15BMl5BanBnXkFtZTgwMTkzNjU2NTM@._V1_UX140_CR0,0,140,209_AL_.jpg";
             //ViewBag.f = "https://m.media-amazon.com/images/M/MV5BNTkxNzMyMDMyNF5BMl5BanBnXkFtZTgwNjYwMzgxNjM@._V1_UX140_CR0,0,140,209_AL_.jpg";
             //ViewBag.g = "https://m.media-amazon.com/images/M/MV5BZWVkMzY5NzgtMTdlNS00NjY5LThjOTktZWFkNDU3NmQzMDIwXkEyXkFqcGdeQXVyODk2NDQ3MTA@._V1_UY209_CR0,0,140,209_AL_.jpg";
             //ViewBag.g1 = "https://m.media-amazon.com/images/M/MV5BZjFiMGUzMTAtNDAwMC00ZjRhLTk0OTUtMmJiMzM5ZmVjODQxXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UY209_CR0,0,140,209_AL_.jpg";
             //ViewBag.g2 = "https://m.media-amazon.com/images/M/MV5BNDg2NjIxMDUyNF5BMl5BanBnXkFtZTgwMzEzNTE1NTM@._V1_UX140_CR0,0,140,209_AL_.jpg";
             //ViewBag.g3 = "https://m.media-amazon.com/images/M/MV5BMTkzMzgzMTc1OF5BMl5BanBnXkFtZTgwNjQ4MzE0NjM@._V1_UY209_CR1,0,140,209_AL_.jpg";
             //ViewBag.g4 = "https://m.media-amazon.com/images/M/MV5BZTI4NTE3ODMtYzBhNi00NmE2LWJjY2QtNTUwY2EzYTAzOWUzXkEyXkFqcGdeQXVyODcyODY1Mzg@._V1_UY209_CR11,0,140,209_AL_.jpg";
             //ViewBag.g5 = "https://m.media-amazon.com/images/M/MV5BMTYyNzEyNDAzOV5BMl5BanBnXkFtZTgwNTk3NDczNjM@._V1_UY209_CR0,0,140,209_AL_.jpg";
             //ViewBag.g6 = "https://m.media-amazon.com/images/M/MV5BYmE5Yjg0MzktYzgzMi00YTFiLWJjYTItY2M5MmI1ODI4MDY3XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX140_CR0,0,140,209_AL_.jpg";
             //ViewBag.g7 = "https://m.media-amazon.com/images/M/MV5BMTcxMjUwNjQ5N15BMl5BanBnXkFtZTgwNjk4MzI4NjM@._V1_UY209_CR0,0,140,209_AL_.jpg";
             //ViewBag.Widows = "https://m.media-amazon.com/images/M/MV5BMjM3ODc5NDEyOF5BMl5BanBnXkFtZTgwMTI4MDcxNjM@._V1_UX140_CR0,0,140,209_AL_.jpg";
             


            string path = BaseDirectory + @"\App_Data\allMovies.json";

            string DataBacePath = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=" + BaseDirectory + @"\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True";
            try
            {// string DataBacePath = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=D:\Example-of-Microservices\WebApplication1\WebApplication1\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True";
                if (proj == "java")
                {


                    Process process = new Process();
                    process.StartInfo.FileName = "java";
                    process.StartInfo.Arguments = "-jar " + BDirectory + @"\retriver.jar" + " jdbc:sqlserver://localhost:1433;databaseName=dbo;integratedSecurity=true;";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.Start();
                    //Read the output (or the error)

                    string output = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(output);
                    string err = process.StandardError.ReadToEnd();
                    Console.WriteLine(err);
                    int a = process.ExitCode;
                    process.WaitForExit();

                    List<Movies> Movie = JsonConvert.DeserializeObject<List<Movies>>(output);
                    ViewBag.moviesList = Movie;
                    TempData["MovieList"] = Movie;

                }
                else
                {

                    Process process = new Process();
                    process.StartInfo.FileName = BDirectory + @"\wecandothis\candoit\bin\Debug\candoit.exe";
                    process.StartInfo.Arguments = DataBacePath + " " + path;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.Start();
                    //Read the output (or the error)
                    string output = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(output);
                    string err = process.StandardError.ReadToEnd();
                    Console.WriteLine(err);
                    process.WaitForExit();
                }
                getMoviesAndGaners();
                ViewBag.moviesList = ((IEnumerable<Movies>)TempData["MovieList"]).Cast<Movies>().ToList();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return View();
            }*/
            return View();

        }



        public ActionResult Top10(string num, string prog)
        {/*
          
            if (num == null)
                num = "10";

            string path = BaseDirectory+@"\App_Data\TopMovies.json";
            string DataBacePath = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=" + BaseDirectory + @"\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True";
            //string DataBacePath = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=D:\Example-of-Microservices\WebApplication1\WebApplication1\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True";
            try
            {
                if (prog == "java")
                {


                    Process process = new Process();
                    process.StartInfo.FileName = "java";
                    process.StartInfo.Arguments = "-jar " + BDirectory + @"\top.jar" + " jdbc:sqlserver://localhost:1433;databaseName=dbo;integratedSecurity=true;";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.Start();
                    //Read the output (or the error)

                    string output = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(output);
                    string err = process.StandardError.ReadToEnd();
                    Console.WriteLine(err);
                    int a = process.ExitCode;
                    process.WaitForExit();
                    List<Movies> Movie = JsonConvert.DeserializeObject<List<Movies>>(output);
                    ViewBag.moviesList = Movie;
                }
                else
                {
                    Process process = new Process();
                    process.StartInfo.FileName = BDirectory + @"\TopMovies\TopMovies\bin\\Debug\TopMovies.exe";
                    process.StartInfo.Arguments = DataBacePath + " " + path + " " + num;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.Start();
                    //Read the output (or the error)
                    string output = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(output);
                    string err = process.StandardError.ReadToEnd();
                    Console.WriteLine(err);
                    process.WaitForExit();
                    using (StreamReader r = new StreamReader(path))
                    {
                        string json = r.ReadToEnd();
                        List<Movies> Movie = JsonConvert.DeserializeObject<List<Movies>>(json);
                        ViewBag.moviesList = Movie;
                    }

                }
                getMoviesAndGaners();
               
            }
            catch (Exception)
            {
                return View();
            }
            ViewBag.num = num;
            return View();
            
        }

        public ActionResult Genre()
        {

            string path = BaseDirectory+ @"\App_Data\allGaners.json";

            string DataBacePath = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename="+ BaseDirectory+@"\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True";
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = BDirectory + @"\ShowGaners\ShowGaners\bin\Debug\ShowGaners.exe";
                process.StartInfo.Arguments = DataBacePath + " " + path;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();
                //Read the output (or the error)
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                string err = process.StandardError.ReadToEnd();
                Console.WriteLine(err);
                process.WaitForExit();

                getMoviesAndGaners();
                ViewBag.GanersList = ((IEnumerable<Ganers>)TempData["GanersList"]).Cast<Ganers>().ToList();
            }
            catch (Exception)
            {
                return View();
            }
            */
            return View();

        }


        public ActionResult MoviesPerGaner(string ganer)
        {/*
            ViewBag.ganer = ganer;
            string path = BaseDirectory+ @"\App_Data\MGaners.json";
            string DataBacePath = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=" + BaseDirectory + @"\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True";
            //string DataBacePath = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=D:\Example-of-Microservices\WebApplication1\WebApplication1\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True";
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = BDirectory + @"\MoviesPerGaner\MoviesPerGaner\bin\Debug\MoviesPerGaner.exe";
                process.StartInfo.Arguments = DataBacePath + " " + path + " " + ganer;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();
                //Read the output (or the error)
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                string err = process.StandardError.ReadToEnd();
                Console.WriteLine(err);
                process.WaitForExit();





                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    List<Movies> Movie = JsonConvert.DeserializeObject<List<Movies>>(json);
                    ViewBag.moviesList = Movie;
                }
                getMoviesAndGaners();
            }
            catch (Exception)
            {
                return View();
            }*/
            return View();
        }
    }
}

