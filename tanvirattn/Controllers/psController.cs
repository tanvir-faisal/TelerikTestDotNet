using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tanvirattn.Models;

namespace tanvirattn.Controllers
{
    public class psController : Controller
    {
        private attntfaEntities db = new attntfaEntities();

        // GET: ps
        public ActionResult Index()
        {
            return View(db.personal_schedule.ToList());
        }

        // GET: ps/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal_schedule personal_schedule = db.personal_schedule.Find(id);
            if (personal_schedule == null)
            {
                return HttpNotFound();
            }
            return View(personal_schedule);
        }

        // GET: ps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalScheduleID,empid,scheduleid,ScheduleStart,SheduleEnd,activityId,show")] personal_schedule personal_schedule)
        {
            if (ModelState.IsValid)
            {
                db.personal_schedule.Add(personal_schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personal_schedule);
        }

        // GET: ps/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal_schedule personal_schedule = db.personal_schedule.Find(id);
            if (personal_schedule == null)
            {
                return HttpNotFound();
            }
            return View(personal_schedule);
        }

        // POST: ps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalScheduleID,empid,scheduleid,ScheduleStart,SheduleEnd,activityId,show")] personal_schedule personal_schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personal_schedule);
        }

        // GET: ps/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal_schedule personal_schedule = db.personal_schedule.Find(id);
            if (personal_schedule == null)
            {
                return HttpNotFound();
            }
            return View(personal_schedule);
        }

        // POST: ps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            personal_schedule personal_schedule = db.personal_schedule.Find(id);
            db.personal_schedule.Remove(personal_schedule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult psreport()
        {
            return View();
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
