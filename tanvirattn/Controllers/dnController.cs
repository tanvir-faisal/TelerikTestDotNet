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
    public class dnController : Controller
    {
        private attntfaEntities db = new attntfaEntities();

        // GET: dn
        public ActionResult Index()
        {
            return View(db.dayNames.ToList());
        }

        // GET: dn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dayName dayName = db.dayNames.Find(id);
            if (dayName == null)
            {
                return HttpNotFound();
            }
            return View(dayName);
        }

        // GET: dn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dayId,dayName1")] dayName dayName)
        {
            if (ModelState.IsValid)
            {
                db.dayNames.Add(dayName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dayName);
        }

        // GET: dn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dayName dayName = db.dayNames.Find(id);
            if (dayName == null)
            {
                return HttpNotFound();
            }
            return View(dayName);
        }

        // POST: dn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dayId,dayName1")] dayName dayName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dayName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dayName);
        }

        // GET: dn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dayName dayName = db.dayNames.Find(id);
            if (dayName == null)
            {
                return HttpNotFound();
            }
            return View(dayName);
        }

        // POST: dn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dayName dayName = db.dayNames.Find(id);
            db.dayNames.Remove(dayName);
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
