﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoUpSchoolProject.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UpSchoolDbPortfolioEntities1 : DbContext
    {
        public UpSchoolDbPortfolioEntities1()
            : base("name=UpSchoolDbPortfolioEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblAbout> TblAbout { get; set; }
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }
        public virtual DbSet<TblMember> TblMember { get; set; }
        public virtual DbSet<TblMessage> TblMessage { get; set; }
        public virtual DbSet<TblServices> TblServices { get; set; }
        public virtual DbSet<TblServicesFeature> TblServicesFeature { get; set; }
        public virtual DbSet<TblTestimonial> TblTestimonial { get; set; }
    }
}
