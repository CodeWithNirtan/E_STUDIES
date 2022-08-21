using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_STUDIES.Models;
using System.IO;
using Microsoft.AspNet.Identity;


namespace E_STUDIES.Controllers
{
    public class Study_resourcesController : Controller
    {
        private estudiezEntities db = new estudiezEntities();

        // GET: Study_resources
        public ActionResult Index()
        {
            var study_resources = db.Study_resources.Include(s => s.User);
            return View(study_resources.ToList());
        }

        // GET: Study_resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study_resources study_resources = db.Study_resources.Find(id);
            if (study_resources == null)
            {
                return HttpNotFound();
            }
            return View(study_resources);
        }

        // GET: Study_resources/Create
        public ActionResult Create()
        {
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID");
            return View();
        }

        // POST: Study_resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Study_resources study_resources)
        {
            HttpPostedFileBase file = Request.Files["imageData"];
            if (study_resources.res_desc != null  && study_resources.Title != null && study_resources.Url_link != null)
            {
                if (file != null)
                {

                    var imagename = study_resources.Resources_id + file.FileName;
                    var imageurl = Path.Combine(Server.MapPath("~/Images"), imagename);
                    file.SaveAs(imageurl);

                    var useremail = User.Identity.GetUserName();
                    var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();
                    var userid = user.userid;

                    Study_resources st = new Study_resources()
                    {

                        res_desc = study_resources.res_desc,
                        Res_status = true,
                        res_img = imagename,
                        Title = study_resources.Title,
                        Url_link = study_resources.Url_link,
                        userid = userid,

                    };
                    try
                    {

                        db.Study_resources.Add(st);
                        db.SaveChanges();

                        return RedirectToAction("index", "home");


                    }
                    catch (Exception)
                    {
                        ViewBag.error = "Error";
                        return View("create");

                        throw;
                    }
                }
                else {
                    return View(study_resources);
                    }
                   //    ViewBag.success = "Your Resource Has been successfully entered";
          
               
            }
            else{

                ViewBag.imgerror = "image not found error";
                return View(study_resources);
            }
        }

        // GET: Study_resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study_resources study_resources = db.Study_resources.Find(id);
            if (study_resources == null)
            {
                return HttpNotFound();
            }
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", study_resources.userid);
            return View(study_resources);
        }

        // POST: Study_resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Resources_id,Title,Url_link,userid,Res_status,res_desc,res_img")] Study_resources study_resources)
        {
            if (ModelState.IsValid)
            {
                db.Entry(study_resources).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", study_resources.userid);
            return View(study_resources);
        }

        // GET: Study_resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Study_resources study_resources = db.Study_resources.Find(id);
            if (study_resources == null)
            {
                return HttpNotFound();
            }
            return View(study_resources);
        }

        // POST: Study_resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Study_resources study_resources = db.Study_resources.Find(id);
            db.Study_resources.Remove(study_resources);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangeStatus(int Resources_id,string Res_status) {

            if (Res_status == "Active")
            {
                db.ChangeStatus(Resources_id, true);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else {
                db.ChangeStatus(Resources_id, false);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
