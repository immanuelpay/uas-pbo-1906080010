using Microsoft.AspNet.Identity.EntityFramework;
using PBO_UAS.Entities;
using PBO_UAS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PBO_UAS
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Semester> Semester { get; set; }
        public DbSet<MataKuliah> MataKuliah { get; set; }
        public DbSet<Mahasiswa> Mahasiswa { get; set; }
        public DbSet<Nilai> Nilai { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");

            modelBuilder.Configurations.Add(new MahasiswaMap());
            modelBuilder.Configurations.Add(new NilaiMap());
        }
    }
}