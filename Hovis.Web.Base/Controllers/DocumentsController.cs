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
    public class DocumentsController : Controller
    {
        private HovisVPDEntities db = new HovisVPDEntities();

        // GET: Documents
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Index(long? id, string status)
        {
            ViewBag.status = status;
            ViewBag.id = id;
            var t_HovisVPD_Documents = db.t_HovisVPD_Documents.Include(t => t.t_HovisVPD_Document_Types_Drop_Down).Include(t => t.t_HovisVPD_Details);
            return View(t_HovisVPD_Documents.ToList()
                .Where(c => c.VPDRefNo == id));
        }

        // GET: Documents/Details/5
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Documents t_HovisVPD_Documents = db.t_HovisVPD_Documents.Find(id);
            if (t_HovisVPD_Documents == null)
            {
                return HttpNotFound();
            }
            return View(t_HovisVPD_Documents);
        }

        // GET: Documents/Create
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Create(long? id)
        {
            ViewBag.DocType = new SelectList(db.t_HovisVPD_Document_Types_Drop_Down, "TypeID", "TypeDescription", "-- Please Pick --");
            //ViewBag.VPDRefNo = new SelectList(db.t_HovisVPD_Details, "VPDRefNo", "VPDRefNo");
           
            var model = new t_HovisVPD_Documents();
            model.VPDRefNo = id.Value;
            model.DateCreated = DateTime.Now;
            return View(model);
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Create([Bind(Include = "RecID,VPDRefNo,Title,Description,Owner,FileLink,DocType,DateCreated")] t_HovisVPD_Documents t_HovisVPD_Documents)
        {
            if (ModelState.IsValid)
            {
                db.t_HovisVPD_Documents.Add(t_HovisVPD_Documents);
                db.SaveChanges();
                return RedirectToAction("Index", "Documents", new { id = t_HovisVPD_Documents.VPDRefNo });
            }

            ViewBag.DocType = new SelectList(db.t_HovisVPD_Document_Types_Drop_Down, "TypeID", "TypeDescription", t_HovisVPD_Documents.DocType);
            ViewBag.VPDRefNo = new SelectList(db.t_HovisVPD_Details, "VPDRefNo", "RaisedBy", t_HovisVPD_Documents.VPDRefNo);
            return View(t_HovisVPD_Documents);
        }

        // GET: Documents/Edit/5
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Documents t_HovisVPD_Documents = db.t_HovisVPD_Documents.Find(id);
            if (t_HovisVPD_Documents == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocType = new SelectList(db.t_HovisVPD_Document_Types_Drop_Down, "TypeID", "TypeDescription", t_HovisVPD_Documents.DocType);
            //ViewBag.VPDRefNo = new SelectList(db.t_HovisVPD_Details, "VPDRefNo", "RaisedBy", t_HovisVPD_Documents.VPDRefNo);
            return View(t_HovisVPD_Documents);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Edit([Bind(Include = "RecID,VPDRefNo,Title,Description,Owner,FileLink,DocType,DateCreated")] t_HovisVPD_Documents t_HovisVPD_Documents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_HovisVPD_Documents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Documents", new { id = t_HovisVPD_Documents.VPDRefNo });
            }
            ViewBag.DocType = new SelectList(db.t_HovisVPD_Document_Types_Drop_Down, "TypeID", "TypeDescription", t_HovisVPD_Documents.DocType);
            ViewBag.VPDRefNo = new SelectList(db.t_HovisVPD_Details, "VPDRefNo", "RaisedBy", t_HovisVPD_Documents.VPDRefNo);
            return View(t_HovisVPD_Documents);
        }

        // GET: Documents/Delete/5
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Documents t_HovisVPD_Documents = db.t_HovisVPD_Documents.Find(id);
            if (t_HovisVPD_Documents == null)
            {
                return HttpNotFound();
            }
            ViewBag.VPDrefNoid = t_HovisVPD_Documents.VPDRefNo;
            return View(t_HovisVPD_Documents);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult DeleteConfirmed(long id)
        {
            t_HovisVPD_Documents t_HovisVPD_Documents = db.t_HovisVPD_Documents.Find(id);
            db.t_HovisVPD_Documents.Remove(t_HovisVPD_Documents);
            db.SaveChanges();
            return RedirectToAction("Index", "Documents", new { id = t_HovisVPD_Documents.VPDRefNo });
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
