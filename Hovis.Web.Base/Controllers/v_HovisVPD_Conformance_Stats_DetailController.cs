using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hovis.Web.Base.Models;

namespace Hovis.Web.Base.Controllers
{
    public class v_HovisVPD_Conformance_Stats_DetailController : Controller
    {
        private HovisVPDEntities db = new HovisVPDEntities();

        // GET: v_HovisVPD_Conformance_Stats_Detail
        public ActionResult Index()
        {
            return View(db.v_HovisVPD_Conformance_Stats_Detail.ToList());
        }

        // GET: v_HovisVPD_Conformance_Stats_Detail/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_HovisVPD_Conformance_Stats_Detail v_HovisVPD_Conformance_Stats_Detail = db.v_HovisVPD_Conformance_Stats_Detail.Find(id);
            if (v_HovisVPD_Conformance_Stats_Detail == null)
            {
                return HttpNotFound();
            }
            return View(v_HovisVPD_Conformance_Stats_Detail);
        }

        // GET: v_HovisVPD_Conformance_Stats_Detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v_HovisVPD_Conformance_Stats_Detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VPDRefNo,WeekRaised,MonthRaised,YearRaised,OpenCritical,AllCritical,OpenMajor,AllMajor,OpenMinor,AllMinor,OpenedLast10Days,ClosedLast10Days,AllOpen,AllClosed,AllLoged,Bakery,SupplierName,ItemCode")] v_HovisVPD_Conformance_Stats_Detail v_HovisVPD_Conformance_Stats_Detail)
        {
            if (ModelState.IsValid)
            {
                db.v_HovisVPD_Conformance_Stats_Detail.Add(v_HovisVPD_Conformance_Stats_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_HovisVPD_Conformance_Stats_Detail);
        }

        // GET: v_HovisVPD_Conformance_Stats_Detail/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_HovisVPD_Conformance_Stats_Detail v_HovisVPD_Conformance_Stats_Detail = db.v_HovisVPD_Conformance_Stats_Detail.Find(id);
            if (v_HovisVPD_Conformance_Stats_Detail == null)
            {
                return HttpNotFound();
            }
            return View(v_HovisVPD_Conformance_Stats_Detail);
        }

        // POST: v_HovisVPD_Conformance_Stats_Detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VPDRefNo,WeekRaised,MonthRaised,YearRaised,OpenCritical,AllCritical,OpenMajor,AllMajor,OpenMinor,AllMinor,OpenedLast10Days,ClosedLast10Days,AllOpen,AllClosed,AllLoged,Bakery,SupplierName,ItemCode")] v_HovisVPD_Conformance_Stats_Detail v_HovisVPD_Conformance_Stats_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_HovisVPD_Conformance_Stats_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_HovisVPD_Conformance_Stats_Detail);
        }

        // GET: v_HovisVPD_Conformance_Stats_Detail/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_HovisVPD_Conformance_Stats_Detail v_HovisVPD_Conformance_Stats_Detail = db.v_HovisVPD_Conformance_Stats_Detail.Find(id);
            if (v_HovisVPD_Conformance_Stats_Detail == null)
            {
                return HttpNotFound();
            }
            return View(v_HovisVPD_Conformance_Stats_Detail);
        }

        // POST: v_HovisVPD_Conformance_Stats_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            v_HovisVPD_Conformance_Stats_Detail v_HovisVPD_Conformance_Stats_Detail = db.v_HovisVPD_Conformance_Stats_Detail.Find(id);
            db.v_HovisVPD_Conformance_Stats_Detail.Remove(v_HovisVPD_Conformance_Stats_Detail);
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
