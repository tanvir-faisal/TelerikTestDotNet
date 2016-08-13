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
    public class doController : Controller
    {
        private attntfaEntities db = new attntfaEntities();

        // GET: do
        public ActionResult Index()
        {
            return View(db.Dayoffs.ToList());
        }

        // GET: do/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dayoff dayoff = db.Dayoffs.Find(id);
            if (dayoff == null)
            {
                return HttpNotFound();
            }
            return View(dayoff);
        }

        // GET: do/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: do/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,empid,dayName,startDate,endDate,show,active,dayId")] Dayoff dayoff)
        {
            if (ModelState.IsValid)
            {
                db.Dayoffs.Add(dayoff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dayoff);
        }

        // GET: do/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dayoff dayoff = db.Dayoffs.Find(id);
            if (dayoff == null)
            {
                return HttpNotFound();
            }
            return View(dayoff);
        }

        // POST: do/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,empid,dayName,startDate,endDate,show,active,dayId")] Dayoff dayoff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dayoff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dayoff);
        }

        // GET: do/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dayoff dayoff = db.Dayoffs.Find(id);
            if (dayoff == null)
            {
                return HttpNotFound();
            }
            return View(dayoff);
        }

        // POST: do/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dayoff dayoff = db.Dayoffs.Find(id);
            db.Dayoffs.Remove(dayoff);
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
