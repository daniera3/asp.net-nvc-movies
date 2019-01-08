﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project.DEL;
using project.Models;

namespace project.Controllers
{
    public class AccountController : Controller
    {
        private Movie_del dal = new Movie_del();
        public ActionResult Register(Register A)
        {
            return View(A);
        }

        public ActionResult SubmitRegister(Register A)
        {
            if (ModelState.IsValid)
            {
                if (A.Password == A.ConfirmPassword)
                {

                        Account account = new Account()
                        {
                            Email = A.Email,
                            Password = A.Password,
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
                        return RedirectToAction("Register", A);
                    }
                    Session["Account"] = account;
                    return RedirectToRoute("Index", "Home");
                }
            }
            TempData["error"] = "incorrect";
            return RedirectToAction("Register", A);
        }

        public ActionResult Login(Account A)
        {

            return View(A);
        }
        public ActionResult SubmitLogin(Account A)
        {
            if (ModelState.IsValid)
            {
                List<Account> T = (from x in dal.Accounts
                            where x.Password.Equals(A.Password) && x.Email.Equals(A.Email)
                             select x).ToList<Account>();
                if(T.Count==0)
                {
                    TempData["error"] = "password or Email incorrect";
                    return View("Login", A);
                }
                
                Session["Account"] = A;
                return View("Index", "Home");
            }
            TempData["error"] = "password or Email incorrect";
            return View("Login",A);
        }
        
        public ActionResult LogOff()
        {

            return View();
        }
    }
}
