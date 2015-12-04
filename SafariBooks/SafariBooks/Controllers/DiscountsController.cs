using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SafariBooks.Models;

namespace SafariBooks.Controllers
{
    public class DiscountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Discounts
        public ActionResult Index()
        {
            return View(db.Discounts.ToList());
        }

        // GET: Discounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discounts discounts = db.Discounts.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }

        // GET: Discounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Discounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiscountsID,discountname,value")] Discounts discounts)
        {
            if (ModelState.IsValid)
            {
                db.Discounts.Add(discounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discounts);
        }

        // GET: Discounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discounts discounts = db.Discounts.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }

        // POST: Discounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiscountsID,discountname,value")] Discounts discounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discounts);
        }

        // GET: Discounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discounts discounts = db.Discounts.Find(id);
            if (discounts == null)
            {
                return HttpNotFound();
            }
            return View(discounts);
        }

        // POST: Discounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Discounts discounts = db.Discounts.Find(id);
            db.Discounts.Remove(discounts);
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
