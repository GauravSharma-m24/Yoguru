﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projrct_home.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JabbaEntities : DbContext
    {
        public JabbaEntities()
            : base("name=JabbaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Register_Table> Register_Table { get; set; }
        public DbSet<TBL_Contact> TBL_Contact { get; set; }
        public DbSet<Tbl_Feedback> Tbl_Feedback { get; set; }
        public DbSet<TBL_Login> TBL_Login { get; set; }
        public DbSet<Tbl_Registration> Tbl_Registration { get; set; }
    }
}
