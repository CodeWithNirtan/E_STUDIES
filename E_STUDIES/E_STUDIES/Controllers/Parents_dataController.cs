using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_STUDIES.Models;
using E_STUDIES.Models.Viewmodels;
using Microsoft.AspNet.Identity;

namespace E_STUDIES.Controllers
{
    [Authorize(Roles ="2")]
    public class Parents_dataController : Controller
    {
        private estudiezEntities db = new estudiezEntities();

        // GET: Parents_data

        public ActionResult Index()
        {
            var parents_data = db.Parents_data.Include(p => p.User);
            return View(parents_data.ToList());
        }

        // GET: Parents_data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parents_data parents_data = db.Parents_data.Find(id);
            if (parents_data == null)
            {
                return HttpNotFound();
            }
            return View(parents_data);
        }

        // GET: Parents_data/Create
        public ActionResult Create()
        {
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID");
            return View();
        }

        // POST: Parents_data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Parent_dataViewModel  PDV)
        {
            if (ModelState.IsValid)
            {

                var useremail = User.Identity.GetUserName();
                var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();

                Parents_data PD = new Parents_data();
                PD.Parents_data_id = PDV.Parents_data_id;
                PD.userid = user.userid;
                PD.phone = PDV.phone;
                PD.Parent_Name = PDV.Parent_Name;
                PD.Parents_address = PDV.Parents_address;
                PD.Cnic = PDV.Cnic;
//Teacher_data td = new Teacher_data();

                db.Parents_data.Add(PD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", PDV.Parents_data_id);
            return View(PDV);
        }

        // GET: Parents_data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parents_data parents_data = db.Parents_data.Find(id);
            if (parents_data == null)
            {
                return HttpNotFound();
            }
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", parents_data.userid);
            return View(parents_data);
        }

        // POST: Parents_data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Parents_data_id,Parent_Name,phone,Cnic,Parents_address,userid")] Parents_data parents_data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parents_data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", parents_data.userid);
            return View(parents_data);
        }

        // GET: Parents_data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parents_data parents_data = db.Parents_data.Find(id);
            if (parents_data == null)
            {
                return HttpNotFound();
            }
            return View(parents_data);
        }

        // POST: Parents_data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parents_data parents_data = db.Parents_data.Find(id);
            db.Parents_data.Remove(parents_data);
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
