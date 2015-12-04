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
    public class CouponsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Coupons
        public ActionResult Index()
        {
            return View(db.Coupons.ToList());
        }

        // GET: Coupons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupons coupons = db.Coupons.Find(id);
            if (coupons == null)
            {
                return HttpNotFound();
            }
            return View(coupons);
        }

        // GET: Coupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CouponsID,CouponTypes,PromotionDetails,Couponvalue")] Coupons coupons)
        {
            if (ModelState.IsValid)
            {
                db.Coupons.Add(coupons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coupons);
        }

        // GET: Coupons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupons coupons = db.Coupons.Find(id);
            if (coupons == null)
            {
                return HttpNotFound();
            }
            return View(coupons);
        }

        // POST: Coupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CouponsID,CouponTypes,PromotionDetails,Couponvalue")] Coupons coupons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coupons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coupons);
        }

        // GET: Coupons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupons coupons = db.Coupons.Find(id);
            if (coupons == null)
            {
                return HttpNotFound();
            }
            return View(coupons);
        }

        // POST: Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Coupons coupons = db.Coupons.Find(id);
            db.Coupons.Remove(coupons);
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
