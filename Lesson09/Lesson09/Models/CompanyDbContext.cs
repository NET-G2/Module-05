using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lesson09.Models
{
    public partial class CompanyDbContext : DbContext
    {
        public CompanyDbContext()
            : base("name=CompanyDbContext1")
        {
        }

        public virtual DbSet<EMP> EMP { get; set; }
        public virtual DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EMP>()
                .Property(e => e.EMPNO)
                .HasPrecision(4, 0);

            modelBuilder.Entity<EMP>()
                .Property(e => e.ENAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMP>()
                .Property(e => e.JOB)
                .IsUnicode(false);

            modelBuilder.Entity<EMP>()
                .Property(e => e.MGR)
                .HasPrecision(4, 0);

            modelBuilder.Entity<EMP>()
                .Property(e => e.SAL)
                .HasPrecision(7, 2);

            modelBuilder.Entity<EMP>()
                .Property(e => e.COMM)
                .HasPrecision(7, 2);

            modelBuilder.Entity<EMP>()
                .Property(e => e.DEPTNO)
                .HasPrecision(2, 0);
        }
    }
}
