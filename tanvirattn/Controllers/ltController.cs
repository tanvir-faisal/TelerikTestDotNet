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
    public class ltController : Controller
    {
        private attntfaEntities db = new attntfaEntities();

        // GET: lt
        public ActionResult Index()
        {
            return View(db.leave_Type.ToList());
        }

        // GET: lt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            leave_Type leave_Type = db.leave_Type.Find(id);
            if (leave_Type == null)
            {
                return HttpNotFound();
            }
            return View(leave_Type);
        }

        // GET: lt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "leaveTypeId,leaveType")] leave_Type leave_Type)
        {
            if (ModelState.IsValid)
            {
                db.leave_Type.Add(leave_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leave_Type);
        }

        // GET: lt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            leave_Type leave_Type = db.leave_Type.Find(id);
            if (leave_Type == null)
            {
                return HttpNotFound();
            }
            return View(leave_Type);
        }

        // POST: lt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "leaveTypeId,leaveType")] leave_Type leave_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leave_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leave_Type);
        }

        // GET: lt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            leave_Type leave_Type = db.leave_Type.Find(id);
            if (leave_Type == null)
            {
                return HttpNotFound();
            }
            return View(leave_Type);
        }

        // POST: lt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            leave_Type leave_Type = db.leave_Type.Find(id);
            db.leave_Type.Remove(leave_Type);
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
