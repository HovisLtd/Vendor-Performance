using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hovis.Web.Base.Models
{
    public class VPDMetaData
    {
        [Display(Name = "Ref No")]
        public int VPDRefNo { get; set; }

        [Display(Name = "Date First Raised")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateFirstRaised { get; set; }

        [Display(Name = "Raised By")]
        public string RaisedBy { get; set; }

        [Display(Name = "Bakery P/O Number")]
        public string BakeryPONumber { get; set; }

        [Display(Name = "Resource Code")]
        public string ItemCode { get; set; }

        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Description of Issue")]
        public string DescriptionOfIssue { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int IssueCategory { get; set; }

        [Required]
        [Display(Name = "Site")]
        public string Bakery { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Display(Name = "Supplier Contact Details")]
        public string SupplierContactDetails { get; set; }

        [Display(Name = "Supplier Contact Name")]
        public string SupplierContactName { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int Priority { get; set; }

        [Display(Name = "Actions Required")]
        public string ActionsRequired { get; set; }

        [Display(Name = "Others Involved")]
        public string OthersInvolved { get; set; }

        [Display(Name = "Last Updates")]
        public string LastUpdates { get; set; }

        [Display(Name = "Close out Comments")]
        public string CloseOutComments { get; set; }

        [Display(Name = "Issue Closure Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> IssueClosureDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Supplier Engagement")]
        public string SupplierEngagement { get; set; }

        [Display(Name = "Supplier Delivery Note No")]
        public string DeliveryLotNo { get; set; }

        [Display(Name = "Delivery Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DeliveryDate { get; set; }

        [Display(Name = "Supplier Complaint Ref(if known)")]
        public string SupplierReferenceNo { get; set; }

    }

    public class DocumentsMetaData
    {
        [Display(Name = "Ref No")]
        public int VPDRefNo { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Owner")]
        public string Owner { get; set; }

        [Display(Name = "Link")]
        public string FileLink { get; set; }

        [Required]
        [Display(Name = "Document Type")]
        public string DocType { get; set; }

        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateCreated { get; set; }
    }

    public class DocumentTypesMetaData
    {
        [Display(Name = "Document Type")]
        public string TypeDescription { get; set; }
    }

    public class CategoryMetaData
    {
        [Display(Name = "Category")]
        public string CatDescription { get; set; }
    }

    public class ContactMetaData
    {
        [Display(Name = "Contact")]
        public string ContactDescription { get; set; }
    }

    public class PriorityMetaData
    {
        [Display(Name = "Priority")]
        public string PriorityDescription { get; set; }
    }

    public class RatingMetaData
    {
        [Display(Name = "Supplier Rating")]
        public string RatingDescription { get; set; }
    }

    public class MyViewModel
    {
        [Display(Name = "Open Critical")]
        public int OpenCriticalA { get; set; }

        [Display(Name = "Open Major")]
        public int OpenMajorA { get; set; }

        [Display(Name = "Open Minor")]
        public int OpenMinorA { get; set; }
        
        [Display(Name = "Total Critical")]
        public int AllCriticalA { get; set; }
        
        [Display(Name = "Total Major")]
        public int AllMajorA { get; set; }
        
        [Display(Name = "Total Minor")]
        public int AllMinorA { get; set; }
        
        [Display(Name = "Open In Last 10 Days")]
        public int OpenLast10daysA { get; set; }
        
        [Display(Name = "Closed In Last 10 Days")]
        public int Closedlast10daysA { get; set; }
        
        [Display(Name = "Total Open")]
        public int AllOpenA { get; set; }
        
        [Display(Name = "Total Closed")]
        public int AllClosedA { get; set; }
        
        [Display(Name = "Total Logged")]
        public int AllLoggedA { get; set; }
    }
}