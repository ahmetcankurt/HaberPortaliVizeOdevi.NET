﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HaberPortali.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HaberPortaliEntities1 : DbContext
    {
        public HaberPortaliEntities1()
            : base("name=HaberPortaliEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Haber> Haber { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }
    }
}
