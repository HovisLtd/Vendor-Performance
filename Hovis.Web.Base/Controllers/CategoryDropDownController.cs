﻿using System;
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
    public class CategoryDropDownController : Controller
    {
        private HovisVPDEntities db = new HovisVPDEntities();

        // GET: CategoryDropDown
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.t_HovisVPD_Category_Drop_Down.ToList());
        }

        // GET: CategoryDropDown/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Category_Drop_Down t_HovisVPD_Category_Drop_Down = db.t_HovisVPD_Category_Drop_Down.Find(id);
            if (t_HovisVPD_Category_Drop_Down == null)
            {
                return HttpNotFound();
            }
            return View(t_HovisVPD_Category_Drop_Down);
        }

        // GET: CategoryDropDown/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryDropDown/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "CatID,CatDescription")] t_HovisVPD_Category_Drop_Down t_HovisVPD_Category_Drop_Down)
        {
            if (ModelState.IsValid)
            {
                db.t_HovisVPD_Category_Drop_Down.Add(t_HovisVPD_Category_Drop_Down);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_HovisVPD_Category_Drop_Down);
        }

        // GET: CategoryDropDown/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Category_Drop_Down t_HovisVPD_Category_Drop_Down = db.t_HovisVPD_Category_Drop_Down.Find(id);
            if (t_HovisVPD_Category_Drop_Down == null)
            {
                return HttpNotFound();
            }
            return View(t_HovisVPD_Category_Drop_Down);
        }

        // POST: CategoryDropDown/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "CatID,CatDescription")] t_HovisVPD_Category_Drop_Down t_HovisVPD_Category_Drop_Down)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_HovisVPD_Category_Drop_Down).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_HovisVPD_Category_Drop_Down);
        }

        // GET: CategoryDropDown/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Category_Drop_Down t_HovisVPD_Category_Drop_Down = db.t_HovisVPD_Category_Drop_Down.Find(id);
            if (t_HovisVPD_Category_Drop_Down == null)
            {
                return HttpNotFound();
            }
            return View(t_HovisVPD_Category_Drop_Down);
        }

        // POST: CategoryDropDown/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            t_HovisVPD_Category_Drop_Down t_HovisVPD_Category_Drop_Down = db.t_HovisVPD_Category_Drop_Down.Find(id);
            db.t_HovisVPD_Category_Drop_Down.Remove(t_HovisVPD_Category_Drop_Down);
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
