using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hovis.Web.Base.Models;
using PagedList;
using Microsoft.Reporting.WebForms;
using System.IO;


namespace Hovis.Web.Base.Controllers
{
    public class DetailsController : Controller
    {
        private HovisVPDEntities db = new HovisVPDEntities();

        // GET: Details
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Index(int? page)
        {
            var t_HovisVPD_Details = db.t_HovisVPD_Details.Include(t => t.t_HovisVPD_Category_Drop_Down).Include(t => t.v_HovisVPD_MasterData_Plants).Include(t => t.t_HovisVPD_Priority_Drop_Down).Include(t => t.t_HovisVPD_Supplier_Rating_Drop_Down);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //return View(t_HovisVPD_Details.ToPagedList(pageNumber, pageSize).OrderByDescending(c => c.VPDRefNo));
            return View(t_HovisVPD_Details.OrderByDescending(c => c.VPDRefNo).ToPagedList(pageNumber, pageSize));

        }

        // GET: SearchDetails
        //[Authorize(Roles = "Admin,VPDcanEdit")]
        //public ActionResult IndexSearch(int? page)
        //{
        //    DateTime SelectedDate = DateTime.Now.AddDays(-7);
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    return View(db.t_HovisVPD_Details
        //    .Where(x => x.DateFirstRaised >= SelectedDate)
        //    .OrderByDescending(x => x.DateFirstRaised).ThenByDescending(x => x.Bakery).ThenBy(x => x.VPDRefNo).ToPagedList(pageNumber, pageSize));
        //}

        // GET: SearchDetails
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult IndexSearch(string currentFilter, string Searchfield, int? page)
        {

            var sfield = Convert.ToString(Searchfield);
            var cFilter = Convert.ToString(currentFilter);

            if (sfield != null)
            {
                page = 1;
            }
            else
            {
                sfield = cFilter;
            }

            ViewBag.CurrentFilter = sfield;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.t_HovisVPD_Details
            .Where(x => x.RaisedBy.Contains(sfield) || x.SupplierName.Contains(sfield) || x.ItemCode.Contains(sfield) || x.ItemDescription.Contains(sfield) || x.Bakery.Contains(sfield) || x.BakeryPONumber.Contains(sfield))
            .OrderByDescending(x => x.DateFirstRaised).ThenByDescending(x => x.Bakery).ThenBy(x => x.VPDRefNo).ToPagedList(pageNumber, pageSize));
        }


        // GET: Details/Details/5
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Details t_HovisVPD_Details = db.t_HovisVPD_Details.Find(id);
            if (t_HovisVPD_Details == null)
            {
                return HttpNotFound();
            }
            
            string Firstnamecharlow = t_HovisVPD_Details.RaisedBy.Substring(0, 1);
            string FirstnamecharUpp = Firstnamecharlow.ToUpper();
            int fulltext = t_HovisVPD_Details.RaisedBy.IndexOf(".") + 1;
            string Surname2char = t_HovisVPD_Details.RaisedBy.Substring(fulltext, 3);
            string Surname2charUpp = Surname2char.ToUpper();
            ViewBag.RefNumber = FirstnamecharUpp + Surname2charUpp + " - " + t_HovisVPD_Details.VPDRefNo;
            return View(t_HovisVPD_Details);
        }

        // GET: Details/ReportDetails/5
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult StartArea(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Details t_HovisVPD_Details = db.t_HovisVPD_Details.Find(id);
            if (t_HovisVPD_Details == null)
            {
                return HttpNotFound();
            }

            string Firstnamecharlow = t_HovisVPD_Details.RaisedBy.Substring(0, 1);
            string FirstnamecharUpp = Firstnamecharlow.ToUpper();
            int fulltext = t_HovisVPD_Details.RaisedBy.IndexOf(".") + 1;
            string Surname2char = t_HovisVPD_Details.RaisedBy.Substring(fulltext, 3);
            string Surname2charUpp = Surname2char.ToUpper();
            ViewBag.RefNumber = FirstnamecharUpp + Surname2charUpp + " - " + t_HovisVPD_Details.VPDRefNo;
            return View(t_HovisVPD_Details);
        }

        public ActionResult Report(string typeid, long? id)
        {
            LocalReport lr = new LocalReport();

            //For this to work with AZURE you must set the report build action to CONTENT and the 
            //Copy to output directory set to DO NOT COPY
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Reports/ReportStartArea.rdlc");
            string pdffilename = "HovisVPD Ref" + id + ".pdf";

            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return RedirectToAction("Index", "Details");
                //return View("Index");
            }
            List<v_HovisVPD_Details> cm = new List<v_HovisVPD_Details>();
            using (HovisVPDEntities dc = new HovisVPDEntities())
            {
                cm = dc.v_HovisVPD_Details.Where(x => x.VPDRefNo == id).ToList();
            }
            ReportDataSource rd = new ReportDataSource("ReportDataSet", cm);
            lr.DataSources.Add(rd);
            string reportType = typeid;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + typeid + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType, pdffilename);
        }

        // GET: Details/Create
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Create()
        {
            ViewBag.IssueCategory = new SelectList(db.t_HovisVPD_Category_Drop_Down, "CatID", "CatDescription", "-- Please Pick --");
            ViewBag.Bakery = new SelectList(db.v_HovisVPD_MasterData_Plants, "Bakery", "BakeryDesc", "-- Please Pick --");
            ViewBag.Priority = new SelectList(db.t_HovisVPD_Priority_Drop_Down, "PriorityID", "PriorityDescription", "-- Please Pick --");
            ViewBag.SupplierEngagement = new SelectList(db.t_HovisVPD_Supplier_Rating_Drop_Down, "RatingID", "RatingDescription", "-- Please Pick --");
            var model = new t_HovisVPD_Details();
            model.RaisedBy = User.Identity.Name;
            model.Status = "Open";
            model.DateFirstRaised = DateTime.Now;
            return View(model);
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Create([Bind(Include = "VPDRefNo,DateFirstRaised,RaisedBy,BakeryPONumber,ItemCode,ItemDescription,DescriptionOfIssue,IssueCategory,Bakery,SupplierName,SupplierContactDetails,SupplierContactName,Priority,ActionsRequired,OthersInvolved,LastUpdates,CloseOutComments,IssueClosureDate,Status,SupplierEngagement,DeliveryLotNo,DeliveryDate,SupplierReferenceNo")] t_HovisVPD_Details t_HovisVPD_Details)
        {
            if (ModelState.IsValid)
            {
                if (t_HovisVPD_Details.RaisedBy == null)
                {
                    t_HovisVPD_Details.RaisedBy = "";
                }
                if (t_HovisVPD_Details.BakeryPONumber == null)
                {
                    t_HovisVPD_Details.BakeryPONumber = "";
                }
                if (t_HovisVPD_Details.ItemCode == null)
                {
                    t_HovisVPD_Details.ItemCode = "";
                }
                if (t_HovisVPD_Details.ItemDescription == null)
                {
                    t_HovisVPD_Details.ItemDescription = "";
                }
                if (t_HovisVPD_Details.DescriptionOfIssue == null)
                {
                    t_HovisVPD_Details.DescriptionOfIssue = "";
                }

                db.t_HovisVPD_Details.Add(t_HovisVPD_Details);
                db.SaveChanges();
                return RedirectToAction("Index","Documents", new { id = t_HovisVPD_Details.VPDRefNo });
            }

            ViewBag.IssueCategory = new SelectList(db.t_HovisVPD_Category_Drop_Down, "CatID", "CatDescription", t_HovisVPD_Details.IssueCategory);
            ViewBag.Bakery = new SelectList(db.v_HovisVPD_MasterData_Plants, "Bakery", "BakeryDesc", t_HovisVPD_Details.Bakery);
            ViewBag.Priority = new SelectList(db.t_HovisVPD_Priority_Drop_Down, "PriorityID", "PriorityDescription", t_HovisVPD_Details.Priority);
            ViewBag.SupplierEngagement = new SelectList(db.t_HovisVPD_Supplier_Rating_Drop_Down, "RatingID", "RatingDescription", t_HovisVPD_Details.SupplierEngagement);
            ViewBag.RaisedBy = User.Identity.Name;
            return View(t_HovisVPD_Details);
        }

        // GET: Details/Edit/5
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Details t_HovisVPD_Details = db.t_HovisVPD_Details.Find(id);
            if (t_HovisVPD_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.IssueCategory = new SelectList(db.t_HovisVPD_Category_Drop_Down, "CatID", "CatDescription", t_HovisVPD_Details.IssueCategory);
            ViewBag.Bakery = new SelectList(db.v_HovisVPD_MasterData_Plants, "Bakery", "BakeryDesc", t_HovisVPD_Details.Bakery);
            ViewBag.Priority = new SelectList(db.t_HovisVPD_Priority_Drop_Down, "PriorityID", "PriorityDescription", t_HovisVPD_Details.Priority);
            ViewBag.SupplierEngagement = new SelectList(db.t_HovisVPD_Supplier_Rating_Drop_Down, "RatingID", "RatingDescription", t_HovisVPD_Details.SupplierEngagement);
            return View(t_HovisVPD_Details);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Edit([Bind(Include = "VPDRefNo,DateFirstRaised,RaisedBy,BakeryPONumber,ItemCode,ItemDescription,DescriptionOfIssue,IssueCategory,Bakery,SupplierName,SupplierContactDetails,SupplierContactName,Priority,ActionsRequired,OthersInvolved,LastUpdates,CloseOutComments,IssueClosureDate,Status,SupplierEngagement,DeliveryLotNo,DeliveryDate,SupplierReferenceNo")] t_HovisVPD_Details t_HovisVPD_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_HovisVPD_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Documents", new { id = t_HovisVPD_Details.VPDRefNo, status = t_HovisVPD_Details.Status });
            }
            ViewBag.IssueCategory = new SelectList(db.t_HovisVPD_Category_Drop_Down, "CatID", "CatDescription", t_HovisVPD_Details.IssueCategory);
            ViewBag.Bakery = new SelectList(db.v_HovisVPD_MasterData_Plants, "Bakery", "BakeryDesc", t_HovisVPD_Details.Bakery);
            ViewBag.Priority = new SelectList(db.t_HovisVPD_Priority_Drop_Down, "PriorityID", "PriorityDescription", t_HovisVPD_Details.Priority);
            ViewBag.SupplierEngagement = new SelectList(db.t_HovisVPD_Supplier_Rating_Drop_Down, "RatingID", "RatingDescription", t_HovisVPD_Details.SupplierEngagement);
            return View(t_HovisVPD_Details);
        }

        // GET: Details/Close/5
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Close(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Details t_HovisVPD_Details = db.t_HovisVPD_Details.Find(id);
            if (t_HovisVPD_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.IssueCategory = new SelectList(db.t_HovisVPD_Category_Drop_Down, "CatID", "CatDescription", t_HovisVPD_Details.IssueCategory);
            ViewBag.Bakery = new SelectList(db.v_HovisVPD_MasterData_Plants, "Bakery", "BakeryDesc", t_HovisVPD_Details.Bakery);
            ViewBag.Priority = new SelectList(db.t_HovisVPD_Priority_Drop_Down, "PriorityID", "PriorityDescription", t_HovisVPD_Details.Priority);
            //db.t_HovisVPD_Supplier_Rating_Drop_Down.Include(new { RatingID = 0, RatingDescription = "-- Please Pick --" });
            //ViewBag.SupplierEngagement = new SelectList(db.t_HovisVPD_Supplier_Rating_Drop_Down, "RatingID", "RatingDescription", t_HovisVPD_Details.SupplierEngagement);

            ViewBag.SupplierEngagement = new SelectList(db.t_HovisVPD_Supplier_Rating_Drop_Down, "RatingID", "RatingDescription", "-- Please Pick --");
            return View(t_HovisVPD_Details);
        }

        // POST: Details/Close/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Close([Bind(Include = "VPDRefNo,DateFirstRaised,RaisedBy,BakeryPONumber,ItemCode,ItemDescription,DescriptionOfIssue,IssueCategory,Bakery,SupplierName,SupplierContactDetails,SupplierContactName,Priority,ActionsRequired,OthersInvolved,LastUpdates,CloseOutComments,IssueClosureDate,Status,SupplierEngagement,DeliveryLotNo,DeliveryDate,SupplierReferenceNo")] t_HovisVPD_Details t_HovisVPD_Details)
        {
            if (ModelState.IsValid)
            {
                TempData["ErrorMess"] = "";
                if (String.IsNullOrEmpty(t_HovisVPD_Details.CloseOutComments))
                {
                    //throw new System.InvalidOperationException("Must enter closure text");
                    //ModelState.AddModelError("CloseOutComments", "Must enter closure text");
                    TempData["ErrorMess"] = "you must enter details in the Close Out Comments section above";
                    return RedirectToAction("Close", "Details", new { id = t_HovisVPD_Details.VPDRefNo });
                }
                t_HovisVPD_Details.IssueClosureDate = DateTime.Now;
                t_HovisVPD_Details.Status = "Closed";
                db.Entry(t_HovisVPD_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Details");
            }
            ViewBag.IssueCategory = new SelectList(db.t_HovisVPD_Category_Drop_Down, "CatID", "CatDescription", t_HovisVPD_Details.IssueCategory);
            ViewBag.Bakery = new SelectList(db.v_HovisVPD_MasterData_Plants, "Bakery", "BakeryDesc", t_HovisVPD_Details.Bakery);
            ViewBag.Priority = new SelectList(db.t_HovisVPD_Priority_Drop_Down, "PriorityID", "PriorityDescription", t_HovisVPD_Details.Priority);
            ViewBag.SupplierEngagement = new SelectList(db.t_HovisVPD_Supplier_Rating_Drop_Down, "RatingID", "RatingDescription", t_HovisVPD_Details.SupplierEngagement);
            return View(t_HovisVPD_Details);
        }

        // GET: Details/Delete/5
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_HovisVPD_Details t_HovisVPD_Details = db.t_HovisVPD_Details.Find(id);
            if (t_HovisVPD_Details == null)
            {
                return HttpNotFound();
            }
            return View(t_HovisVPD_Details);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,VPDcanEdit")]
        public ActionResult DeleteConfirmed(long id)
        {
            t_HovisVPD_Details t_HovisVPD_Details = db.t_HovisVPD_Details.Find(id);
            db.t_HovisVPD_Details.Remove(t_HovisVPD_Details);
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
