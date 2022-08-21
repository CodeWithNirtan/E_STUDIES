using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_STUDIES.Models;
using E_STUDIES.Models.Viewmodels;
using Microsoft.AspNet.Identity;

namespace E_STUDIES.Controllers
{

    
    public class HomeController : Controller
    {
        estudiezEntities db = new estudiezEntities();

     [Authorize]
        public ActionResult Index()
        {
            
            return View(db.Study_resources.Where(x=>x.Res_status == true).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(Contactus_ViewModel cvm)
        {


            if (ModelState.IsValid)
            {
                var useremail = User.Identity.GetUserName();
                var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();
                Contact_us contact_us = new Contact_us();
                contact_us.email = cvm.email;
                contact_us.Subjects = cvm.Subjects;
                contact_us.Contact_us_messages = cvm.Contact_us_messages;
                contact_us.userid = user.userid;

                db.Contact_us.Add(contact_us);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", cvm.Contact_us_id);
            return View(cvm);
        }
    }
}