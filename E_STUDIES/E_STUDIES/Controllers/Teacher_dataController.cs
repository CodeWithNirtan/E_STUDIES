using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_STUDIES.Models;
using E_STUDIES.Models.Students_data_viewmodels;
using Microsoft.AspNet.Identity;
using System.IO;

namespace E_STUDIES.Controllers
{
    [Authorize(Roles = "3")]
    public class Teacher_dataController : Controller
    {
        private estudiezEntities db = new estudiezEntities();

        // GET: Teacher_data
        public ActionResult Index()
        {

            var useremail = User.Identity.GetUserName();
            var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();
            var userid = user.userid;
            var teacher_data = db.Teacher_data.Where(x => x.userid == userid).FirstOrDefault();
            if (teacher_data == null || user == null)
            {

                return View("create");

            }
            ViewBag.data = user;
            return View(teacher_data);
        }

        // GET: Teacher_data/Details/5/data
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher_data teacher_data = db.Teacher_data.Find(id);
            if (teacher_data == null)
            {
                return HttpNotFound();
            }
            return View(teacher_data);
        }

        // GET: Teacher_data/Create
        public ActionResult Create()
        {
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID");
            return View();
        }

        // POST: Teacher_data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher_DataViewmodel tdv)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["imageData"];
                if (file != null)
                {

                    var imagename = tdv.Teacher_data_id + file.FileName;
                    var imageurl = Path.Combine(Server.MapPath("~/Images"), imagename);
                    file.SaveAs(imageurl);
                    
                    var useremail = User.Identity.GetUserName();
                    var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();
                    Teacher_data td = new Teacher_data();
                    td.Teacher_image = imagename;
                    td.phone = tdv.phone;
                    td.Fullname = tdv.Fullname;
                    td.userid = user.userid;
                    td.Marital_status = tdv.Marital_status;
                    td.Fullname = tdv.Fullname;
                    td.Qualification = tdv.Qualification;
                    td.Teacher_address = tdv.Teacher_address;
                    td.Experience = tdv.Experience;
                    td.age = tdv.age;
                    td.gender = tdv.gender;
                    
                    db.Teacher_data.Add(td);
                    db.SaveChanges();

                }
                else {
                    ViewBag.imageerror = "Please select the valid image";
                }
                
                
                //database login here
                return RedirectToAction("Index");
            }

            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", tdv.Teacher_data_id);
            return View(tdv);
        }

        // GET: Teacher_data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher_data td = db.Teacher_data.Find(id);

            if (td == null)
            {
                return HttpNotFound();
            }
            Teacher_DataViewmodel   tdv = new Teacher_DataViewmodel()
            {
                age = td.age,
                Experience = td.Experience,
                Fullname = td.Fullname,
                gender = td.gender,
                phone = td.phone,
                Marital_status = td.Marital_status,
                Teacher_address = td.Teacher_address,
                Qualification = td.Qualification,
                Teacher_data_id = td.Teacher_data_id
                
            };
            var useremail = User.Identity.GetUserName();
            var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();
            var userid = user.userid;
            var teacher_data = db.Teacher_data.Where(x => x.userid == userid).FirstOrDefault();
            if (teacher_data == null || user == null)
            {

                return View("create");

            }
            ViewBag.data = user;
            ViewBag.teacherimg = teacher_data.Teacher_image;

            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", td.userid);
            return View(tdv);
        }

        // POST: Teacher_data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher_DataViewmodel tdv)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["imageData"];
                var imagename = tdv.Teacher_data_id + file.FileName;
                var useremail = User.Identity.GetUserName();
                var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();
                var userid = user.userid;
                //var teacher = db.Teacher_data.Where(x => x.userid==userid).FirstOrDefault();
                //var teacherid = teacher.Teacher_data_id;
                Teacher_data td = new Teacher_data()
                {
                    age = tdv.age,
                    Experience = tdv.Experience,
                    Fullname = tdv.Fullname,
                    gender = tdv.gender,
                    phone = tdv.phone,
                    Marital_status = tdv.Marital_status,
                    Teacher_address = tdv.Teacher_address,
                    Qualification = tdv.Qualification,
                    Teacher_data_id = tdv.Teacher_data_id,
                    Teacher_image = imagename,
                    userid = userid
                   
                  
                   
                    
                    
                };


                db.Entry(td).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tdv);
        }

        // GET: Teacher_data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher_data teacher_data = db.Teacher_data.Find(id);
            if (teacher_data == null)
            {
                return HttpNotFound();
            }
            return View(teacher_data);
        }

        // POST: Teacher_data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher_data teacher_data = db.Teacher_data.Find(id);
            db.Teacher_data.Remove(teacher_data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //get method of add_resources
  
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
