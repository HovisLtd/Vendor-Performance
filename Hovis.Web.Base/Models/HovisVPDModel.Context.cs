﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HovisVPDEntities : DbContext
    {
        public HovisVPDEntities()
            : base("name=HovisVPDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<t_HovisVPD_Category_Drop_Down> t_HovisVPD_Category_Drop_Down { get; set; }
        public virtual DbSet<t_HovisVPD_Contact_Mode_Drop_Down> t_HovisVPD_Contact_Mode_Drop_Down { get; set; }
        public virtual DbSet<t_HovisVPD_Document_Types_Drop_Down> t_HovisVPD_Document_Types_Drop_Down { get; set; }
        public virtual DbSet<t_HovisVPD_Priority_Drop_Down> t_HovisVPD_Priority_Drop_Down { get; set; }
        public virtual DbSet<t_HovisVPD_Supplier_Rating_Drop_Down> t_HovisVPD_Supplier_Rating_Drop_Down { get; set; }
        public virtual DbSet<t_HovisVPD_Transaction_Log> t_HovisVPD_Transaction_Log { get; set; }
        public virtual DbSet<v_HovisVPD_MasterData_Plants> v_HovisVPD_MasterData_Plants { get; set; }
        public virtual DbSet<t_HovisVPD_Details> t_HovisVPD_Details { get; set; }
        public virtual DbSet<t_HovisVPD_Documents> t_HovisVPD_Documents { get; set; }
        public virtual DbSet<v_HovisVPD_Conformance_Stats_Detail> v_HovisVPD_Conformance_Stats_Detail { get; set; }
        public virtual DbSet<v_HovisVPD_Details> v_HovisVPD_Details { get; set; }
    }
}
