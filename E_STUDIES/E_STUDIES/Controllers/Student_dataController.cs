using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_STUDIES.Models;
using Microsoft.AspNet.Identity;
using E_STUDIES.Models.Students_data_viewmodels;

namespace E_STUDIES.Controllers
{
    public class Student_dataController : Controller
    {
        private estudiezEntities db = new estudiezEntities();

        // GET: Student_data
        [Authorize(Roles ="1")]
        public ActionResult Index()
        {

            var useremail = User.Identity.GetUserName();
            var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();
            var userid = user.userid;
            var teacher_data = db.Student_data.Where(x => x.userid == userid).FirstOrDefault();
            if (teacher_data == null || user == null)
            {

                return RedirectToAction("create");

            }
            ViewBag.data = user;
            return View(teacher_data);
        }

        // GET: Student_data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_data student_data = db.Student_data.Find(id);
            if (student_data == null)
            {
                return HttpNotFound();
            }
            return View(student_data);
        }

        // GET: Student_data/Create
        public ActionResult Create()
        {
        
          
           
            return View();
        }

        // POST: Student_data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student_dataViewModel svm)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["imageData"];
                if (file != null)
                {

                    var imagename = svm.Student_data_id + file.FileName;
                    var imageurl = Path.Combine(Server.MapPath("~/Images"), imagename);
                    file.SaveAs(imageurl);
                    var useremail = User.Identity.GetUserName();
                    var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();
                    var userid = user.userid;


                    Student_data sd = new Student_data()
                    {
                        Enrollment_date = svm.Enrollment_date,
                        Fullname = svm.Fullname,
                        phone = svm.phone,
                        Gender = "gender",
                        Student_address = svm.Student_address,
                        Student_age = svm.Student_age,
                        Student_image = imagename,
                        Student_data_id = userid




                    };

                    db.Student_data.Add(sd);
                    db.SaveChanges();

                }
                else
                {
                    ViewBag.imageerror = "Please select the valid image";
                }


                //database login here
                return RedirectToAction("Index");
            }

            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", svm.Student_data_id);
            return View(svm);

        }

        // GET: Student_data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_data student_data = db.Student_data.Find(id);
            if (student_data == null)
            {
                return HttpNotFound();
            }
            ViewBag.Teacher_data_id = new SelectList(db.Teacher_data, "Teacher_data_id", "Fullname", student_data.Teacher_data_id);
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", student_data.userid);
            return View(student_data);
        }

        // POST: Student_data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_data_id,Fullname,Enrollment_date,Student_address,Student_age,phone,Student_image,Teacher_data_id,userid")] Student_data student_data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teacher_data_id = new SelectList(db.Teacher_data, "Teacher_data_id", "Fullname", student_data.Teacher_data_id);
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", student_data.userid);
            return View(student_data);
        }

        // GET: Student_data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_data student_data = db.Student_data.Find(id);
            if (student_data == null)
            {
                return HttpNotFound();
            }
            return View(student_data);
        }

        // POST: Student_data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_data student_data = db.Student_data.Find(id);
            db.Student_data.Remove(student_data);
            db.SaveChanges();
            return RedirectToAction("Index");
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
