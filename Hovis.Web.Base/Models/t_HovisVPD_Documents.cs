//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hovis.Web.Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_HovisVPD_Documents
    {
        public long RecID { get; set; }
        public long VPDRefNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string FileLink { get; set; }
        public int DocType { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual t_HovisVPD_Document_Types_Drop_Down t_HovisVPD_Document_Types_Drop_Down { get; set; }
        public virtual t_HovisVPD_Details t_HovisVPD_Details { get; set; }
    }
}
