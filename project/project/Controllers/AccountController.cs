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
        private DataLayer dal = new DataLayer();
        public ActionResult Register(Register A)
        {
            return View(A);
        }
        [HttpPost]
        public ActionResult SubmitRegister(Register A)
        {
            if (ModelState.IsValid)
            {
                if (A.Password == A.ConfirmPassword)
                {
                    Encryption enc = new Encryption();
                    String hashPass = enc.CreateHash(A.Password);

                        Account account = new Account()
                        {
                            Email = A.Email,
                            Password = hashPass,
                            Admin = false
                        };
                    try
                    {
                        dal.Accounts.Add(account);
                        dal.SaveChanges();
                    }
                   catch (Exception)
                    {
                        TempData["error"] = "Email using";
                        return View("Register", A);
                    }
                    Session["Account"] = account;
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["error"] = "incorrect";
            return View("Register", A);
        }

        public ActionResult Login(Account A)
        {

            return View(A);
        }
        [HttpPost]
        public ActionResult SubmitLogin(Account A)
        {
            Encryption enc = new Encryption();
            if (ModelState.IsValid)
            {
                List<Account> T = (from x in dal.Accounts
                            where x.Email.Equals(A.Email)
                             select x).ToList<Account>();
                if(T.Count==0)
                {
                    TempData["error"] = "password or\and Email incorrect";
                    return View("Login", A);
                }
                if (enc.ValidatePassword(A.Password, T[0].Password))
                    {
                    if (T[0].Admin == true)
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
            FormsAuthentication.SignOut();
            Session.Abandon();


            return RedirectToAction("Index", "Home");
        }
    }
}
