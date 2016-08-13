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
    public class snController : Controller
    {
        private attntfaEntities db = new attntfaEntities();

        // GET: sn
        public ActionResult Index()
        {
            return View(db.signatures.ToList());
        }

        // GET: sn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            signature signature = db.signatures.Find(id);
            if (signature == null)
            {
                return HttpNotFound();
            }
            return View(signature);
        }

        // GET: sn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "signatureid,empid,punch_time")] signature signature)
        {
            if (ModelState.IsValid)
            {
                db.signatures.Add(signature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(signature);
        }

        // GET: sn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            signature signature = db.signatures.Find(id);
            if (signature == null)
            {
                return HttpNotFound();
            }
            return View(signature);
        }

        // POST: sn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "signatureid,empid,punch_time")] signature signature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signature);
        }

        // GET: sn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            signature signature = db.signatures.Find(id);
            if (signature == null)
            {
                return HttpNotFound();
            }
            return View(signature);
        }

        // POST: sn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            signature signature = db.signatures.Find(id);
            db.signatures.Remove(signature);
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
