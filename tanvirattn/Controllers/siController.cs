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
    public class siController : Controller
    {
        private attntfaEntities db = new attntfaEntities();

        // GET: si
        public ActionResult Index()
        {
            return View(db.schedule_info.ToList());
        }

        // GET: si/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schedule_info schedule_info = db.schedule_info.Find(id);
            if (schedule_info == null)
            {
                return HttpNotFound();
            }
            return View(schedule_info);
        }

        // GET: si/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: si/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "scheduleId,ScheduleName,startTime,start_bf,start_af,end_time,end_bf,end_af,activie,show")] schedule_info schedule_info)
        {
            if (ModelState.IsValid)
            {
                db.schedule_info.Add(schedule_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedule_info);
        }

        // GET: si/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schedule_info schedule_info = db.schedule_info.Find(id);
            if (schedule_info == null)
            {
                return HttpNotFound();
            }
            return View(schedule_info);
        }

        // POST: si/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "scheduleId,ScheduleName,startTime,start_bf,start_af,end_time,end_bf,end_af,activie,show")] schedule_info schedule_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedule_info);
        }

        // GET: si/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schedule_info schedule_info = db.schedule_info.Find(id);
            if (schedule_info == null)
            {
                return HttpNotFound();
            }
            return View(schedule_info);
        }

        // POST: si/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            schedule_info schedule_info = db.schedule_info.Find(id);
            db.schedule_info.Remove(schedule_info);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult siReport()
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
