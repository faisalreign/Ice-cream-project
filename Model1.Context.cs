﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ICECREAMPROJECT.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ICECREAMPROJECTEntities : DbContext
    {
        public ICECREAMPROJECTEntities()
            : base("name=ICECREAMPROJECTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_MEMBERSHIP> TBL_MEMBERSHIP { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }
        public virtual DbSet<tbl_feedback> tbl_feedback { get; set; }
        public virtual DbSet<tbl_flavors> tbl_flavors { get; set; }
        public virtual DbSet<tbl_recipe> tbl_recipe { get; set; }
    }
}
