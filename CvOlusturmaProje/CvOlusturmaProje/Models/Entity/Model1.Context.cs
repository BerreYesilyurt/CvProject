﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CvOlusturmaProje.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbCvEntities : DbContext
    {
        public DbCvEntities()
            : base("name=DbCvEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Admin> Tbl_Admin { get; set; }
        public virtual DbSet<Tbl_Deneyimlerim> Tbl_Deneyimlerim { get; set; }
        public virtual DbSet<Tbl_Eğitimlerim> Tbl_Eğitimlerim { get; set; }
        public virtual DbSet<Tbl_Hakkimda> Tbl_Hakkimda { get; set; }
        public virtual DbSet<Tbl_Hobilerim> Tbl_Hobilerim { get; set; }
        public virtual DbSet<Tbl_Iletisim> Tbl_Iletisim { get; set; }
        public virtual DbSet<Tbl_Sertifikalarım> Tbl_Sertifikalarım { get; set; }
        public virtual DbSet<Tbl_Yeteneklerim> Tbl_Yeteneklerim { get; set; }
        public virtual DbSet<tbl_SosyalMedya> tbl_SosyalMedya { get; set; }
    }
}
