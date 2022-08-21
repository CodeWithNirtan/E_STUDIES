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
    public class Score_detailsController : Controller
    {
        private estudiezEntities db = new estudiezEntities();

        // GET: Score_details
        public ActionResult Index()
        {
            //    if(db.Users.ToList().Where(x => x.User_role.Equals(1) ).ToList())
            //var score_details = db.Score_details.Include(s => s.User);

            var useremail = User.Identity.GetUserName();
            var user = db.Users.Where(x => x.Email_ID.Equals(useremail)).FirstOrDefault();
            var userrole = user.User_role;
            var userid = user.userid;
            if (User.IsInRole("1"))
            {
             
                List<Score_details> stdudentscore = db.Score_details.Where(x => x.userid == userid).ToList();
                return View(stdudentscore);
                    

            }
            if (User.IsInRole("3")) {

                View(db.Score_details.ToList());
            }
            
            return View(db.Score_details.ToList());
        }


        public ActionResult insertStudentScore()
        {
            var a = db.Users.ToList().Where(x => x.User_role.Equals(1)).ToList();
            return View(a);
        }

        // GET: Score_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score_details score_details = db.Score_details.Find(id);
            if (score_details == null)
            {
                return HttpNotFound();
            }
            return View(score_details);
        }

        // GET: Score_details/Create
        public ActionResult Create()
        {
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID");
            return View();
        }

        // POST: Score_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public String Create(Score_details[] Score_details)
        {

            DateTime dateTime = DateTime.UtcNow.Date;
            foreach (var item in Score_details)
            {


                Score_details s = new Score_details()
                {

                    Score_id = item.Score_id,
                    Total_Marks = item.Total_Marks,
                    Score_receive = item.Score_receive,
                    userid = item.userid,
                    Score_description = item.Score_description,
                    course=item.course,
                    Issued_date = dateTime,
               
                };
                db.Score_details.Add(s);
            }
            db.SaveChanges();
            var result = "success";
            return result;
        }

        // GET: Score_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score_details score_details = db.Score_details.Find(id);
            if (score_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", score_details.userid);
            return View(score_details);
        }

        // POST: Score_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Score_id,Total_Marks,Score_receive,Issued_date,Score_description,userid")] Score_details score_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userid = new SelectList(db.Users, "userid", "Email_ID", score_details.userid);
            return View(score_details);
        }

        // GET: Score_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score_details score_details = db.Score_details.Find(id);
            if (score_details == null)
            {
                return HttpNotFound();
            }
            return View(score_details);
        }

        // POST: Score_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Score_details score_details = db.Score_details.Find(id);
            db.Score_details.Remove(score_details);
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
