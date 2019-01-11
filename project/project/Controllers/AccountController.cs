using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using project.DEL;
using project.Models;
using project.ModelView;

namespace project.Controllers
{
    public class AccountController : Controller
    {
        private DataLayer dal = new DataLayer();//DAL
        public ActionResult Register(Register A)//Receives object of type Register of name A and sends it to the Register view.
        {
            return View(A);
        }


        [HttpPost]
        public ActionResult SubmitRegister(Register A)//Responsible of the new user adding.
        {
            if (ModelState.IsValid)//Checks if the form fields qualify the restrictions given in the Account model/class.
            {
                if (A.Password == A.ConfirmPassword)
                {
                    Encryption enc = new Encryption();
                    String hashPass = enc.CreateHash(A.Password);//Encryption of the password. Creates a new string from auto salt and pw and hashes it.

                        Account account = new Account()//Account creating.
                        {
                            Email = A.Email,
                            Password = hashPass,
                            Admin = false
                        };
                    try
                    {
                        dal.Accounts.Add(account);//Adds in the memory.
                        dal.SaveChanges();//Saves in the database.
                    }
                   catch (Exception)
                    {
                        TempData["error"] = "Account already exists";
                        return View("Register", A);
                    }
                    Session["Account"] = account;
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["error"] = "incorrect";
            return View("Register", A);
        }

        public ActionResult Login(Account A)//Like Register.
        {

            return View(A);
        }
        [HttpPost]
        public ActionResult SubmitLogin(Account A)
        {
            Encryption enc = new Encryption();
            if (ModelState.IsValid)
            {
                List<Account> T = (from x in dal.Accounts//Query to find the account with given email.
                            where x.Email.Equals(A.Email)
                             select x).ToList<Account>();
                if(T.Count==0)//Check if such account was found.
                {
                    TempData["error"] = "password or Email incorrect";
                    return View("Login", A);
                }
                if (enc.ValidatePassword(A.Password, T[0].Password))//Check password.
                    {
                    if (T[0].Admin == true)//Gives permission only to the admin. Checks if is admin.
                        FormsAuthentication.SetAuthCookie("cookie", true);
                    Session["Account"] = A;
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["error"] = "password or Email incorrect";
            return View("Login",A);
        }
        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();//Deletes the cookie.
            Session.Abandon();//Deletes from memory the login.


            return RedirectToAction("Index", "Home");//Redirects to home.
        }
        
    }
}
